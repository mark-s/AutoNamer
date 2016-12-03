using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using AutoNamer.Core;

namespace AutoNamer.Epub
{
    public class EpubDetailsProvider : IBookDataService
    {
        private readonly ISectionParser _sectionParser;
        public string FileTypeIHandle => "*.epub";
        public ISubject<IBook> Books { get; } = new Subject<IBook>();

        public EpubDetailsProvider(ISectionParser sectionParser)
        {
            _sectionParser = sectionParser;
        }

        
        private static bool FilterOpfFileName(ZipArchiveEntry entry)
            => entry.FullName.EndsWith(".opf", StringComparison.OrdinalIgnoreCase);

        public void ParseBooks(IObservable<FileInfo> fileList)
            => fileList.Subscribe(async f => Books.OnNext(await GetBookDetailsAsync(f)));

        private async Task<IBook> GetBookDetailsAsync(FileInfo file)
        {
            var opfFileText = await GetOpfFileContentsAsync(file.FullName);

            if (string.IsNullOrEmpty(opfFileText))
                return new RenameableBook(file, new SpineData("Unknown", "Unknown"));

            var title = _sectionParser.GetTitle(opfFileText);
            var author = _sectionParser.GetAuthor(opfFileText);

            return new RenameableBook(file, new SpineData(title, author));
        }
        
        private async Task<string> GetOpfFileContentsAsync(string fullFileName)
        {
            var fileContents = "";

            try
            {
                using (var archive = ZipFile.OpenRead(fullFileName))
                {
                    var theOpfFile = archive.Entries.FirstOrDefault(FilterOpfFileName);

                    if (theOpfFile != null)
                        using (var reader = new StreamReader(theOpfFile.Open()))
                        {
                            fileContents = await reader.ReadToEndAsync();
                        }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return fileContents;
        }

    }
}
