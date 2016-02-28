namespace AutoNamer.Core
{
    public class BookFileData
    {
        public string FileName { get; }

        public string FullPath { get;  }

        public string FullPathAndFileName { get;  }

        public BookFileData(string fullPath, string fileName, string fullPathAndFileName)
        {
            FullPath = fullPath;
            FileName = fileName;
            FullPathAndFileName = fullPathAndFileName;
        }
    }
}
