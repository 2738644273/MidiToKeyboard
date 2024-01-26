using MidiToKeyboard.App.ViewModels;
using Prism.DryIoc;
using System.Configuration;
using System.Data;
using System.Windows;
using MidiToKeyboard.App.Views;
using MidiToKeyboard.App.Views.Controls;
using System.Reflection;

namespace MidiToKeyboard.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<MidiListControl,MidiListControl>();
            containerRegistry.RegisterForNavigation<ConsoleControl,ConsoleControlViewModel>();
            containerRegistry.RegisterForNavigation<OperatingStationControl,OperatingStationControlViewModel>();

        }


        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }

}
