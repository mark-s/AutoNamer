using System.Collections.Generic;
using System.Threading.Tasks;
using AutoNamer.Entities;
using AutoNamer.IO;

namespace AutoNamer.UI.ViewModel
{
    public interface IFileHelpers
    {
        string SelectedFolder { get; }
        List<FileDataItem> BooksInFolder { get; }
        void OpenFolder();
        void LoadFolderBookList(string path);
        Task<BookDataItem> GetBookData(FileDataItem file);
    }
}