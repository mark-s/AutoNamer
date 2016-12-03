using System.Collections.Generic;
using System.IO;

namespace AutoNamer.IO
{
    public interface IFileListService
    {
        IEnumerable<FileInfo> GetFileList(string path, string fileExtension, bool includeSubDirectories);
    }
}