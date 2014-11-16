using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using AutoNamer.IO;
using AutoNamer.UI.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using PropertyChanged;

namespace AutoNamer.UI.ViewModel
{
    
    [ImplementPropertyChanged]
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IFileHelpers _fileHelpers;
        public RelayCommand ShowFolderChoice { get; private set; }

        public ObservableCollection<Book> Books { get; private set; }    

        public MainWindowViewModel(IFileHelpers fileHelpers)
        {
            SimpleIoc.Default.Register<MainWindowViewModel>();

            _fileHelpers = fileHelpers;
            
            Books = new ObservableCollection<Book>();

            ShowFolderChoice = new RelayCommand(HandleFolderChoice, () => true);
        }

        private void HandleFolderChoice()
        {
            _fileHelpers.OpenFolder();
            _fileHelpers.LoadFolderBookList(_fileHelpers.SelectedFolder);

            AssignBooks(_fileHelpers.BooksInFolder);
        }

        private async void AssignBooks(IEnumerable<FileDataItem> booksInFolder)
        {
            Books.Clear();

            foreach (var item in booksInFolder)
            {
                var bookData = await _fileHelpers.GetBookData(item);
                Books.Add(new Book(item,bookData));
            }
        }
    }
}