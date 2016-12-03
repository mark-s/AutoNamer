using AutoNamer.Core;

namespace AutoNamer.IO
{
    public class RenameFailure: IRenameResult
    {
        public IBook Book { get; } 
        public bool IsError { get; } = true;
        public string ErrorText { get; } 

        public RenameFailure(IBook book, string errorText)
        {
            ErrorText = errorText;
            Book = book;
        }

    }
}