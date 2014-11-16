using System.Windows;
using AutoNamer.Epub;
using AutoNamer.IO;
using AutoNamer.UI.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace AutoNamer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            SimpleIoc.Default.Register<IFileHelpers, FileHelpers>();
            SimpleIoc.Default.Register<IFolderUtils, FolderUtils>();
            SimpleIoc.Default.Register<IBookDetailsProvider, EpubDetailsProvider>();
            
        }
    }
}
