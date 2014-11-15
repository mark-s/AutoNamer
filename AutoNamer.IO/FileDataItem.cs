using PropertyChanged;

namespace AutoNamer.IO
{

    [ImplementPropertyChanged]
    public class FileDataItem
    {
        private static int _id;

        public int ID { get; private set; }
        public FileInfo Current{ get; private set; }
        public FileInfo Requested { get; private set; }

        public FileDataItem(string path, string fileName, string fileExtension, string fullPath)
        {
            ID = _id++;
            Current = new FileInfo(path, fileName, fileExtension, fullPath);
            Requested = new FileInfo();
        }
    }
}
