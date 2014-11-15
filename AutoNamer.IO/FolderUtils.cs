using System.Collections.Generic;
using System.IO;

namespace AutoNamer.IO
{
    public class FolderUtils
    {

        private const string EPUB_EXTENSION = "*.epub";

        public List<FileDataItem> GetBooksFromFolder(string path, string fileExtension = EPUB_EXTENSION)
        {

            var foundFiles = new List<FileDataItem>();

            foreach (var file in Directory.GetFiles(path, fileExtension))
            {
                var filePath = Path.GetDirectoryName(file);
                var fileName = Path.GetFileNameWithoutExtension(file);
                var fileType = Path.GetExtension(file);
                foundFiles.Add(new FileDataItem(filePath, fileName, fileType, file));
            }

            return foundFiles;
        }
    }
}
