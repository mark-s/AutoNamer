using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoNamer.Entities;
using AutoNamer.IO;

namespace AutoNamer.UI.ViewModel
{
    public interface IFileHelpers
    {
        string SelectedFolder { get; }
        List<FileDataItem> BooksInFolder { get; }
        DialogResult OpenFolder();
        void LoadFolderBookList(string path);
        Task<BookDataItem> GetBookData(FileDataItem file);
    }
}