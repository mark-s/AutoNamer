using PropertyChanged;

namespace AutoNamer.IO
{

    [ImplementPropertyChanged]
    public class FileDataItem
    {
        public FileInfo Current{ get; private set; }
        public FileInfo Proposed { get; private set; }

        public FileDataItem(string path, string fileName, string fileExtension, string fullPath)
        {
            Current = new FileInfo(path, fileName, fileExtension, fullPath);
            Proposed = new FileInfo();
        }
    }
}
