using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using AutoNamer.Entities;

namespace AutoNamer.Epub
{
    public class EpubDetailsProvider : IBookDetailsProvider
    {

        // TODO: Regex may or may not be the fastest way of doing this ...
        private readonly Regex _regexAuthor;
        private readonly Regex _regexTitle;
        private const string AUTHOR = @"<.*creator.*>(.*)</.*creator>";
        private const string TITLE = @"<.*title>(.*)</.*title>";

        public EpubDetailsProvider()
        {
            _regexAuthor = new Regex(AUTHOR, RegexOptions.IgnoreCase | RegexOptions.Compiled );
            _regexTitle = new Regex(TITLE, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        public BookDataItem GetBookData(string fullFileName)
        {
            var bookData = BookDataItem.EmptyBookData;

            string opfFileText;
            if (TryGetOPFFileContents(fullFileName, out opfFileText))
            {
                bookData = new BookDataItem(GetTitle(opfFileText), GetAuthor(opfFileText));
            }

            return bookData;
        }


        private bool TryGetOPFFileContents(string fullFileName, out string fileContents)
        {
            fileContents = null;

            using (var archive = ZipFile.Open(fullFileName, ZipArchiveMode.Read))
            {
                var theOpfFile = archive.Entries.FirstOrDefault(entry => entry.FullName.EndsWith(".opf", StringComparison.OrdinalIgnoreCase));

                if (theOpfFile != null)
                    using (var reader = new StreamReader(theOpfFile.Open()))
                    {
                    // TODO: Make this use a) the Async version and b) only read in the first 20 or so lines for speed
                        fileContents = reader.ReadToEnd();
                    }
            }

            return !String.IsNullOrEmpty(fileContents);
        }

        private string GetAuthor(string opfText)
        {
            var authorMatch = _regexAuthor.Match(opfText);
            return authorMatch.Success ? authorMatch.Groups[1].Value : String.Empty;
        }

        private string GetTitle(string opfText)
        {
            var titleMatch = _regexTitle.Match(opfText);
            return titleMatch.Success ? titleMatch.Groups[1].Value : String.Empty;
        }

    }
}
