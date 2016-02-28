using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
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


        public async Task<IList<BookData>> GetBooksFromFolder(string path, bool includeSubDirectories)
        {

            var items = new List<BookData>();

            foreach (var bookFileData in _fileListService.GetBooksFromFolder(path, FileTypeIHandle, includeSubDirectories))
            {
                items.Add(new BookData(bookFileData, await GetBookSpineData(bookFileData.FullPathAndFileName)));
            }

            return items;
        }






        private async Task<SpineData> GetBookSpineData(string fullFileName)
        {
            SpineData bookData;

            var opfFileText = await GetOPFFileContents(fullFileName);

            if (string.IsNullOrEmpty(opfFileText) == false)
            {
                var title = await GetTitle(opfFileText);
                var author = await GetAuthor(opfFileText);
                bookData = new SpineData(title, author);
            }
            else
            {
                bookData = new SpineData("Unknown", "Unknown");
            }

            return bookData;
        }


        private async Task<string> GetOPFFileContents(string fullFileName)
        {
            string fileContents = "";

            try
            {
                using (var archive = ZipFile.Open(fullFileName, ZipArchiveMode.Read))
                {
                    Debug.WriteLine(fullFileName);
                    var theOpfFile = archive.Entries.FirstOrDefault(entry => entry.FullName.EndsWith(".opf", StringComparison.OrdinalIgnoreCase));

                    if (theOpfFile != null)
                        using (var reader = new StreamReader(theOpfFile.Open()))
                        {
                            fileContents += await reader.ReadToEndAsync();
                        }
                }
            }
            catch (InvalidDataException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return fileContents;
        }

        private async Task<string> GetAuthor(string opfText)
        {
            return await Task<string>.Factory.StartNew(() =>
            {
                var authorMatch = _regexAuthor.Match(opfText);
                if (authorMatch.Success)
                    return authorMatch.Groups[1].Value;
                else
                    return string.Empty;
            });
        }

        private async Task<string> GetTitle(string opfText)
        {
            return await Task<string>.Factory.StartNew(() =>
            {
                var titleMatch = _regexTitle.Match(opfText);
                if (titleMatch.Success)
                    return titleMatch.Groups[1].Value;
                else
                    return string.Empty;
            });
        }


    }
}
