using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using PropertyChanged;

namespace AutoNamer.UI.ViewModel
{
    
    [ImplementPropertyChanged]
    public class MainWindowViewModel : ViewModelBase
    {
        public string SelectedFolder { get; private set; }

        public RelayCommand ShowFolderChoice { get; private set; }

        public List<Book> Books { get; set; }    

        public MainWindowViewModel(IFileHelpers fileHelpers)
        {
            SimpleIoc.Default.Register<MainWindowViewModel>();

            fileHelpers.SelectedFolderChanged += (o, args) => SelectedFolder = args.SelectedFolder;
            
            Books = new List<Book>();

            ShowFolderChoice = new RelayCommand(fileHelpers.OpenFolder, () => true);

        }


    }
}