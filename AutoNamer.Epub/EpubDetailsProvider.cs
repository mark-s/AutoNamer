using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoNamer.Core;
using AutoNamer.IO;

namespace AutoNamer.Epub
{
    public class EpubDetailsProvider : IBookDataService
    {
        private readonly IFileListService _fileListService;

        // TODO: Regex may or may not be the fastest way of doing this ...
        private readonly Regex _regexAuthor;
        private readonly Regex _regexTitle;
        private const string AUTHOR = @"<.{0,30}:creator.{0,150}>(.+)<\/.{0,10}:creator>";
        private const string TITLE = @"<.{0,30}:title.{0,30}>(.+)<\/.{0,30}:title>";

        public string FileTypeIHandle => "*.epub";



        public EpubDetailsProvider(IFileListService fileListService)
        {
            _fileListService = fileListService;
            _regexAuthor = new Regex(AUTHOR, RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(1));
            _regexTitle = new Regex(TITLE, RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(1));
        }


        public IEnumerable<BookData> GetBooksFromFolder(string path, bool includeSubDirectories)
        {

            foreach (var bookFileData in _fileListService.GetBooksFromFolder(path, FileTypeIHandle, includeSubDirectories))
            {
                yield return new BookData(bookFileData, GetBookSpineData(bookFileData.FullPathAndFileName));
            }

        }






        private SpineData GetBookSpineData(string fullFileName)
        {
            SpineData bookData;

            var opfFileText = GetOPFFileContents(fullFileName);

            if (string.IsNullOrEmpty(opfFileText))
            {
                bookData = new SpineData("Unknown", "Unknown");
            }
            else
            {
                var titleTast = Task.Factory.StartNew(() => GetTitle(opfFileText));
                var authorTast = Task.Factory.StartNew(() => GetAuthor(opfFileText));

                var title = titleTast.Result;
                var author = authorTast.Result;

                bookData = new SpineData(title, author);
            }

            return bookData;
        }


        private string GetOPFFileContents(string fullFileName)
        {
            string fileContents = "";

            try
            {
                using (var archive = ZipFile.Open(fullFileName, ZipArchiveMode.Read))
                {

                    var theOpfFile = archive.Entries.FirstOrDefault(entry => entry.FullName.EndsWith(".opf", StringComparison.OrdinalIgnoreCase));

                    if (theOpfFile != null)
                        using (var reader = new StreamReader(theOpfFile.Open()))
                        {
                            fileContents = reader.ReadToEnd();
                        }
                }
            }
            catch (InvalidDataException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return fileContents;
        }

        private string GetAuthor(string opfText)
        {
            var authorMatch = _regexAuthor.Match(opfText);
            if (authorMatch.Success)
                return authorMatch.Groups[1].Value;
            else
                return string.Empty;
        }

        private string GetTitle(string opfText)
        {
            var titleMatch = _regexTitle.Match(opfText);
            if (titleMatch.Success)
                return titleMatch.Groups[1].Value;
            else
                return string.Empty;
        }


    }
}
