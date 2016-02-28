using AutoNamer.Core;
using PropertyChanged;

namespace AutoNamer.UI.Model
{
    [ImplementPropertyChanged]
    public class Book
    {
        public bool Selected { get; set; }

        public string FileName => BookData.FileData.FileName;

        public string Title { get; set; }

        public string Author { get; set; }

        public BookData BookData { get; private set; }

        public bool SavedOk { get; set; }

        public Book(BookData bookData)
        {
            BookData = bookData;
            Title = bookData.Spine.Title;
            Author = bookData.Spine.Author;
        }

        public void UpdateBookData(BookData bookData)
        {
            BookData = bookData;
            Title = bookData.Spine.Title;
            Author = bookData.Spine.Author;
        }

    }

}
