using System.Collections.Generic;
using System.IO;
using AutoNamer.Core;


namespace AutoNamer.IO
{
    public class FileListService : IFileListService
    {
        public IEnumerable<BookFileData> GetBooksFromFolder(string path, string fileExtension, bool includeSubDirectories)
        {
            var searchOption = includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            foreach (var file in Directory.EnumerateFileSystemEntries(path, fileExtension, searchOption))
            {
                var filePath = Path.GetDirectoryName(file);
                var fileName = Path.GetFileNameWithoutExtension(file);

                yield return  new BookFileData(filePath, fileName, file);
            }

        }
    }
}
