using System.Windows;
using AutoNamer.Core;
using AutoNamer.Epub;
using AutoNamer.IO;
using AutoNamer.UI.Helpers;
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

            
            SimpleIoc.Default.Register<IDialogHelpers, DialogHelpers>();
            SimpleIoc.Default.Register<IFileListService, FileListService>();
            SimpleIoc.Default.Register<IBookDataService, EpubDetailsProvider>();
            SimpleIoc.Default.Register<IFileNameService, FileNameService>();
            
        }
    }
}
