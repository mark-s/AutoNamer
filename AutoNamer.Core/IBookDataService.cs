using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoNamer.Core
{
    public interface IBookDataService
    {

         string FileTypeIHandle { get;  }

        IEnumerable<BookData> GetBooksFromFolder(string path, bool includeSubDirectories);


    }
}