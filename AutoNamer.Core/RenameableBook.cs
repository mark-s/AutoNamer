using System.IO;

namespace AutoNamer.Core
{
    public class RenameableBook : IBook
    {
        public SpineData Spine { get;  }
        public IEditableName Name { get; set; }
        public FileInfo File { get;  }

        public RenameableBook(FileInfo file, SpineData spine)
        {
            File = file;
            Spine = spine;
            Name = new BookFileName(Path.GetFileNameWithoutExtension(File.Name));
        }
    }
}
