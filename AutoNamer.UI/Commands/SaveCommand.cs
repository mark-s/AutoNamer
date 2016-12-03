using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoNamer.Core;
using AutoNamer.IO;
using AutoNamer.UI.Model;

namespace AutoNamer.UI.Commands
{
    public class SaveCommand : ICommand
    {
        private readonly ObservableCollection<BookModel> _books;
        private readonly IFileNameService _fileNameService;

        public event EventHandler CanExecuteChanged;
        private void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);


        public SaveCommand(ObservableCollection<BookModel> books, IFileNameService fileNameService)
        {
            _books = books;
            _fileNameService = fileNameService;

            _books.CollectionChanged += (s, e) => RaiseCanExecuteChanged();
        }


        public async void Execute(object parameter) => await ExecuteAsync();
        
        public bool CanExecute(object parameter) => _books.Any();


        public async Task ExecuteAsync()
        {
            foreach (var selectedBook in _books.Where(b => b.IsSelected))
            {
                selectedBook.RenameResult = await Task.Run(() => _fileNameService.RenameFile(selectedBook.Book, GetNameAndExtension));
                selectedBook.IsSelected = false;
            }
        }

        
        private string GetNameAndExtension(IBook book) => Path.ChangeExtension(book.Name.NewName, book.File.Extension);
    }
}
