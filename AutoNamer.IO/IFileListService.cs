using System.Collections.Generic;
using AutoNamer.Core;


namespace AutoNamer.IO
{
    public interface IFileListService
    {
        IEnumerable<BookFileData> GetBooksFromFolder(string path, string fileExtension, bool includeSubDirectories);
    }
}