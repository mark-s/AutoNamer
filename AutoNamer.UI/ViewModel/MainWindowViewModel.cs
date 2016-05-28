using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using AutoNamer.Core;
using AutoNamer.IO;
using AutoNamer.UI.Commands;
using AutoNamer.UI.Helpers;
using AutoNamer.UI.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using PropertyChanged;

namespace AutoNamer.UI.ViewModel
{

    [ImplementPropertyChanged]
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IBookDataService _bookDataService;
        private readonly IDialogHelpers _dialogHelpers;

        public RelayCommand ShowFolderChoice { get; private set; }
        public ICommand SaveCommand { get; private set; }

        

        public ObservableCollection<Book> Books { get; }

        public MainWindowViewModel(IBookDataService bookDataService, IDialogHelpers dialogHelpers, IFileNameService fileNameService)
        {

            SimpleIoc.Default.Register<MainWindowViewModel>();

            _bookDataService = bookDataService;
            _dialogHelpers = dialogHelpers;

            Books = new ObservableCollection<Book>();

            ShowFolderChoice = new RelayCommand(ChoseFolder, () => true);

            SaveCommand = new SaveCommand(Books, fileNameService);

        }

        private void ChoseFolder()
        {
            // Show the open folder dialog
            var selectedFolder = _dialogHelpers.GetFolderChoice();

            if (string.IsNullOrEmpty(selectedFolder))
                return;
            else
                 PopulateBooks(selectedFolder);
        }

        private  void PopulateBooks(string selectedFolder)
        {
            // TODO: Get user choice for sub folders

            Books.Clear();

            var observable = _bookDataService.GetBooksFromFolder(selectedFolder, true).ToObservable();
            observable.Subscribe(new AnonymousObserver<BookData>(x => Books.Add(new Book(x))));
            

        }
    }
}