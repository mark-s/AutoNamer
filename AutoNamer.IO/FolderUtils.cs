using System.Collections.Generic;
using System.IO;
using AutoNamer.Entities;

namespace AutoNamer.IO
{
    public interface IFolderUtils
    {
        List<FileDataItem> GetBooksFromFolder(string path, string fileExtension = BookFileTypeExtensions.EPUB);
    }

    public class FolderUtils : IFolderUtils
    {
        public List<FileDataItem> GetBooksFromFolder(string path, string fileExtension = BookFileTypeExtensions.EPUB)
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
