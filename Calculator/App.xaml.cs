using System.Windows;
using Calculator.Core.Calculators;
using Calculator.Views;
using Prism.Ioc;
using Prism.Unity;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICalculator, ExpressionCalculator>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}
