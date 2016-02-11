using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoNamer.Entities;
using AutoNamer.Epub;
using AutoNamer.IO;

namespace AutoNamer.UI.ViewModel
{
    public class FileHelpers : IFileHelpers
    {

        public List<FileDataItem> BooksInFolder { get; private set; }
        public String SelectedFolder { get; private set; }

        private readonly IFolderUtils _folderUtils;
        private readonly IBookDetailsProvider _bookDetailsProvider;


        public FileHelpers(IFolderUtils folderUtils, IBookDetailsProvider bookDetailsProvider)
        {
            _folderUtils = folderUtils;
            _bookDetailsProvider = bookDetailsProvider;
            BooksInFolder = new List<FileDataItem>();
        }

        public void OpenFolder()
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.ShowNewFolderButton = false;
                folderDialog.Description = "Please select a folder containing the ePubs to Rename";

                var result = folderDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    SelectedFolder = folderDialog.SelectedPath;
                }
            }
        }

        public void LoadFolderBookList(string path)
        {
            BooksInFolder.Clear();
            BooksInFolder.AddRange(_folderUtils.GetBooksFromFolder(path));
        }

        public async Task<BookDataItem> GetBookData(FileDataItem file)
        {
            return await _bookDetailsProvider.GetBookData(file.Current.CompleteFileName);

        }


    }


}
