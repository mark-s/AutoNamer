using System;
using System.IO;
using AutoNamer.Core;


namespace AutoNamer.IO
{
    public class FileNameService : IFileNameService
    {
        private readonly IFileNameValidator _fileNameValidator;

        public FileNameService(IFileNameValidator fileNameValidator)
        {
            _fileNameValidator = fileNameValidator;
        }

        public IRenameResult RenameFile(IBook book, Func<IBook,string> renamer)
        {
            IRenameResult result;

            var newFileNameAndExtension = renamer(book);
            if (_fileNameValidator.IsValidFileName(newFileNameAndExtension) == false)
                return new RenameFailure(book, "new FileName Is Invalid!");
            
            try
            {
                var newFullName = Path.Combine(book.File.DirectoryName, newFileNameAndExtension);
                File.Move(book.File.FullName, newFullName);
                result = new RenameSuccess(book);

                book.Name.SaveNew();
            }
            catch (Exception ex)
            {
                result = new RenameFailure(book, ex.Message);
            }

            return result;

        }

    }
}