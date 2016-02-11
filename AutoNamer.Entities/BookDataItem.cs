using PropertyChanged;

namespace AutoNamer.Entities
{
    [ImplementPropertyChanged]
    public class BookDataItem
    {
        public static BookDataItem EmptyBookData = new BookDataItem("Unknown", "Unknown", string.Empty);
        public SpineData Current { get; private set; }
        public SpineData Proposed { get; private set; }
        public string RawData { get; private set; }

        public BookDataItem(string title, string author, string rawData)
        {
            RawData = rawData;
            Current = new SpineData(title, author);
            Proposed = new SpineData();
        }

    }
}
