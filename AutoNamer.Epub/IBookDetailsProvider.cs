using System.Threading.Tasks;
using AutoNamer.Entities;

namespace AutoNamer.Epub
{
    public interface IBookDetailsProvider
    {
        Task<BookDataItem> GetBookData(string fullFileName);
    }
}