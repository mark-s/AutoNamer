using AutoNamer.Entities;
using AutoNamer.IO;
using PropertyChanged;

namespace AutoNamer.UI.Model
{
    [ImplementPropertyChanged]
    public class Book
    {
        public bool Selected { get; set; }
        public FileDataItem FileData { get; private set; }
        public BookDataItem BookData { get; private set; }
        public Book(FileDataItem fileData, BookDataItem bookData)
        {
            BookData = bookData;
            FileData = fileData;
        }

    }

}
