using AutoNamer.Core;
using AutoNamer.IO;
using PropertyChanged;

namespace AutoNamer.UI.Model
{
    [ImplementPropertyChanged]
    public class BookModel
    {
        public IBook Book { get; }


        public bool IsSelected { get; set; }


        public string Title => Book.Spine.Title;

        public string Author => Book.Spine.Author;

        public IEditableName FileName { get; }

        public bool? SavedOk => !RenameResult?.IsError;

        public IRenameResult RenameResult { get; set; }

        public BookModel(IBook book)
        {
            Book = book;
            FileName = book.Name;
            FileName.NewName = Title;
        }

    }

}
