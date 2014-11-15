using System.CodeDom;
using PropertyChanged;

namespace AutoNamer.IO
{

    [ImplementPropertyChanged]
    public class FileInfo
    {
        public string Path { get; set; }
        public string FileName { get; set; }

        public string FileExtension { get; set; }

        internal FileInfo() { }

        internal FileInfo(string path, string filename, string fileExtension)
        {
            Path = path;
            FileName = filename;
            FileExtension = fileExtension;
        }
    }
}