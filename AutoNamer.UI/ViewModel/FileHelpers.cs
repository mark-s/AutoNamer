using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoNamer.UI.ViewModel
{

    public class FolderSelectionChangedEventArgs : EventArgs
    {
        public string SelectedFolder { get; private set; }
        public List<Book> Books { get; private set; }    

        public FolderSelectionChangedEventArgs(string selectedFolder, List<Book> books)
        {
            Books = books;
            SelectedFolder = selectedFolder;
        }
    }

    public interface IFileHelpers
    {
        event EventHandler<FolderSelectionChangedEventArgs> SelectedFolderChanged;
        String SelectedFolder { get; }
        void OpenFolder();
    }

    public class FileHelpers : IFileHelpers
    {

        public event EventHandler<FolderSelectionChangedEventArgs> SelectedFolderChanged;
        protected virtual void OnSelectedFolderChanged(string folderName)
        {
            var handler = SelectedFolderChanged;
            if (handler != null) handler(this, new FolderSelectionChangedEventArgs(folderName,new List<Book>()));
        }

        public String SelectedFolder { get; private set; }


        public FileHelpers()
        {
            
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
                    OnSelectedFolderChanged(SelectedFolder);
                }
            }
        }
    }

    
}
