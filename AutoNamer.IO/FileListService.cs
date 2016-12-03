using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutoNamer.IO
{
    public class FileListService : IFileListService
    {
        public IEnumerable<FileInfo> GetFileList(string path, string fileExtension, bool includeSubDirectories)
        {
            var searchOption = includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            return Directory.EnumerateFileSystemEntries(path, fileExtension, searchOption)
                .AsParallel()
                .Where(d => !Directory.Exists(d) && d.Length < 256) // Don't forget the length restriction on the file names!
                .Select(e => new FileInfo(e));
        }
    }
}
