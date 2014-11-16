using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AutoNamer.IO;

namespace AutoNamer.UI.ViewModel
{

    public interface IFileHelpers
    {
        String SelectedFolder { get; }
        List<FileDataItem> BooksInFolder { get; }

        void OpenFolder();
        void LoadFolderBookList(string path);
    }

    public class FileHelpers : IFileHelpers
    {

        public List<FileDataItem> BooksInFolder { get; private set; }
        public String SelectedFolder { get; private set; }

        private readonly IFolderUtils _folderUtils;


        public FileHelpers(IFolderUtils folderUtils)
        {
            _folderUtils = folderUtils;
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


    }


}
