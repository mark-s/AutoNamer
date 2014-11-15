using AutoNamer.Entities;
using AutoNamer.IO;
using PropertyChanged;

namespace AutoNamer.UI.ViewModel
{
    [ImplementPropertyChanged]
    public class Book
    {
        public FileDataItem FileData { get; private set; }
        public BookDataItem BookData { get; private set; }

        public Book(FileDataItem fileData, BookDataItem bookData)
        {
            BookData = bookData;
            FileData = fileData;
        }

    }

}
