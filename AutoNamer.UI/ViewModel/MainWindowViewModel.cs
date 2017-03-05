using System;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Input;
using AutoNamer.Core;
using AutoNamer.Epub;
using AutoNamer.IO;
using AutoNamer.UI.Commands;
using AutoNamer.UI.Helpers;
using AutoNamer.UI.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PropertyChanged;

namespace AutoNamer.UI.ViewModel
{

    [ImplementPropertyChanged]
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogHelpers _dialogHelpers;
        private readonly IFileListService _fileListService;

        public RelayCommand ShowFolderChoiceCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public ObservableCollection<BookModel> Books { get; } = new ObservableCollection<BookModel>();

        public MainWindowViewModel(IDialogHelpers dialogHelpers, IFileNameService fileNameService, IFileListService fileListService)
        {
            _dialogHelpers = dialogHelpers;
            _fileListService = fileListService;

            ShowFolderChoiceCommand = new RelayCommand(ChoseFolder);
            SaveCommand = new SaveCommand(Books, fileNameService);
        }

        private void ChoseFolder()
        {
            // Show the open folder dialog
            var selectedFolder = _dialogHelpers.GetFolderChoice();

            if (string.IsNullOrEmpty(selectedFolder)) return;

            PopulateBooks(selectedFolder);

        }

        private void PopulateBooks(string selectedFolder)
        {
            // TODO: Get user choice for sub folders

            Books.Clear();

            var bookDetailsProvider = new EpubDetailsProvider(new EpubSectionParser());


            var observableFileList = _fileListService.GetFileList(selectedFolder, bookDetailsProvider.FileTypeIHandle, true)
                                                .ToObservable(Scheduler.Default);

            bookDetailsProvider.Books.ObserveOn(SynchronizationContext.Current)
                                              .Subscribe(book => Books.Add(new BookModel(book, DefaultNameMaker)));

            bookDetailsProvider.ParseBooks(observableFileList);

        }

        private string DefaultNameMaker(IBook book)
        {
            // TODO: strip out bad characters and check length etc
            return book.Spine.Title;
        }
    }
}