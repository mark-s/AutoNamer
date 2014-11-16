using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoNamer.Entities;

namespace AutoNamer.Epub
{
    public class EpubDetailsProvider : IBookDetailsProvider
    {

        // TODO: Regex may or may not be the fastest way of doing this ...
        private readonly Regex _regexAuthor;
        private readonly Regex _regexTitle;
        private const string AUTHOR = @"<.{1,3}:creator>(.*)</.{1,3}:creator>";
        private const string TITLE = @"<.{1,3}:title>(.*)</.{1,3}:title>";

        public EpubDetailsProvider()
        {
            _regexAuthor = new Regex(AUTHOR, RegexOptions.IgnoreCase | RegexOptions.Compiled,TimeSpan.FromSeconds(1));
            _regexTitle = new Regex(TITLE, RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(1));
        }

        public async Task<BookDataItem> GetBookData(string fullFileName)
        {
            var bookData = BookDataItem.EmptyBookData;

            var opfFileText = await GetOPFFileContents(fullFileName);

            

            if (string.IsNullOrEmpty(opfFileText) == false)
            {
                var title = await GetTitle(opfFileText);
                var author = await GetAuthor(opfFileText);
                bookData = new BookDataItem(title, author);
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
                                       return authorMatch.Success ? authorMatch.Groups[1].Value : String.Empty;
                                   });
        }

        private async Task<string> GetTitle(string opfText)
        {
            return await Task<string>.Factory.StartNew(() =>
                                {
                                    var titleMatch = _regexTitle.Match(opfText);
                                    return titleMatch.Success ? titleMatch.Groups[1].Value : String.Empty;
                                });
        }

    }
}
