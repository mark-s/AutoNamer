using System.IO;

namespace AutoNamer.Core
{
    public interface IBook
    {
        FileInfo File { get; }
        SpineData Spine { get; }
        IEditableName Name { get; set; }
    }
}