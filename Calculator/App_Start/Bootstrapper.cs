using Calculator.Core.Calculators;
using Unity;

namespace Calculator.App_Start
{
    public static class Bootstrapper
    {
        static Bootstrapper()
        {
            Container = new UnityContainer();
        }

        public static IUnityContainer Container { get; }

        public static IUnityContainer RegisterSingeltions(this IUnityContainer container)
        {
            container.RegisterSingleton<ICalculator, ExpressionCalculator>();
            return container;
        }

        public static IUnityContainer RegisterInstances(this IUnityContainer container)
        {
            return container;
        }
    }
}