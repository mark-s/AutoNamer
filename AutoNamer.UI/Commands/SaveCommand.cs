using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AutoNamer.IO;
using AutoNamer.UI.Model;

namespace AutoNamer.UI.Commands
{
    public class SaveCommand : ICommand
    {
        private readonly ObservableCollection<Book> _books;
        private readonly IFileNameService _fileNameService;


        public event EventHandler CanExecuteChanged;

        public SaveCommand(ObservableCollection<Book> books, IFileNameService fileNameService)
        {
            _books = books;
            _fileNameService = fileNameService;

            _books.CollectionChanged += (sender, args) => RaiseCanExecuteChanged();
        }


        public bool CanExecute(object parameter)
        {
            return _books.Any();
        }

        public void Execute(object args)
        {
            // TODO - Make this async !

            foreach (var selectedBook in _books.Where(b => b.Selected))
            {
                var updatedBookData = _fileNameService.RenameFile(selectedBook.BookData);
                selectedBook.UpdateBookData(updatedBookData);
                selectedBook.SavedOk = true;
                selectedBook.Selected = false;
            }
            
        }

        private void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
