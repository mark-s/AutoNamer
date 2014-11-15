using PropertyChanged;

namespace AutoNamer.Entities
{
    [ImplementPropertyChanged]
    public class BookDataItem
    {
        private static int _id;
        public int ID { get; private set; }
        public SpineData Current { get; private set; }
        public SpineData Requested { get; private set; }

        public BookDataItem()
        {
            ID = _id++;
            Current = new SpineData();
            Requested = new SpineData();
        }

    }
}
