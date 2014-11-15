using PropertyChanged;

namespace AutoNamer.IO
{

    [ImplementPropertyChanged]
    public class FileInfo
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string CompleteFileName { get; private set; }

        internal FileInfo() { }

        internal FileInfo(string filePath, string filename, string fileExtension,string fullPath)
        {
            FilePath = filePath;
            FileName = filename;
            FileExtension = fileExtension;
            CompleteFileName = fullPath;

        }
    }
}