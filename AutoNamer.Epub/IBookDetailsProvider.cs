using AutoNamer.Entities;

namespace AutoNamer.Epub
{
    public interface IBookDetailsProvider
    {
        BookDataItem GetBookData(string fullFileName);
    }
}