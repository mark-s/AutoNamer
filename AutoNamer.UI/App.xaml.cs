using System.Windows;
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
        }
    }
}
