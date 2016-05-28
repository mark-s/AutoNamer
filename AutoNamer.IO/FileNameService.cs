using System.IO;
using AutoNamer.Core;

namespace AutoNamer.IO
{
    public class FileNameService : IFileNameService
    {
        public BookData RenameFile(BookData bookData)
        {
            // TODO: Validation here!
            var oldFullPath = bookData.FileData.FullPathAndFileName;
            var extension = Path.GetExtension(oldFullPath);

            var newFileName = Path.ChangeExtension(bookData.Spine.Title, extension);
            var newFullPath = Path.Combine(bookData.FileData.FullPath, newFileName);


            // TODO: ERROR HANDLING!!
            File.Move(oldFullPath, newFullPath);

            return new BookData(new BookFileData(bookData.FileData.FullPath, newFileName, newFullPath), bookData.Spine);

        }
    }
}