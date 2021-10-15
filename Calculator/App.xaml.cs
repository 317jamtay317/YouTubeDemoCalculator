using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow();

            mainWindow.Closed += (s, ex) => Shutdown();
            mainWindow.Show();
        }
    }
}
