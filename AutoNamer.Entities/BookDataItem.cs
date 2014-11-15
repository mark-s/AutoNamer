using PropertyChanged;

namespace AutoNamer.Entities
{
    [ImplementPropertyChanged]
    public class BookDataItem
    {
        private static int _id;

        public static BookDataItem EmptyBookData = new BookDataItem("Unknown", "Unknown");

        public int ID { get; private set; }
        public SpineData Current { get; private set; }
        public SpineData Requested { get; private set; }

        public BookDataItem(string title, string author)
        {
            ID = _id++;
            Current = new SpineData(title, author);
            Requested = new SpineData();
        }

    }
}
