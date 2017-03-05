using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AutoNamer.Core
{
    public class BookFileName : IEditableName, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _newName;
        private string _currentName;

        public string CurrentName
        {
            get { return _currentName; }
            private set
            {
                if (value == _currentName) return;

                _currentName = value;
                OnPropertyChanged();
            }
        }

        public string NewName
        {
            get { return _newName; }
            set
            {
                if (value == _newName) return;

                _newName = value;
                OnPropertyChanged();
            }
        }

        public void SaveNew() => CurrentName = _newName;

        public BookFileName(string currentName)
        {
            CurrentName = currentName;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}