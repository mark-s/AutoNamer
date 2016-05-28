using AutoNamer.Core;

namespace AutoNamer.IO
{
    public interface IFileNameService
    {
        /// <summary>
        /// Return the new updated properties
        /// </summary>
        /// <param name="bookData"></param>
        /// <returns></returns>
        BookData RenameFile(BookData bookData);
    }
}