using AutoNamer.Core;

namespace AutoNamer.IO
{
    public class RenameSuccess : IRenameResult
    {
        public IBook Book { get; }
        public bool IsError { get; } = false;
        public string ErrorText { get; } = string.Empty;

        public RenameSuccess(IBook book)
        {
            Book = book;
        }

    }
}