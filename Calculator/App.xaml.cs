using System.Windows;
using Calculator.App_Start;
using Calculator.ViewModels;
using Unity;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected IUnityContainer Container = Bootstrapper.Container;
        protected override void OnStartup(StartupEventArgs e)
        {
            Container.RegisterSingeltions().RegisterSingeltions();
            var viewModel = Container.Resolve<MainWindowViewModel>();
            var mainWindow = new MainWindow(){DataContext = viewModel};

            mainWindow.Closed += (s, ex) => Shutdown();
            mainWindow.Show();
        }
    }
}
