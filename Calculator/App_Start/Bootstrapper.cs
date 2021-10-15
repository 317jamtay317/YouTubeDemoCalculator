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
            return container;
        }

        public static IUnityContainer RegisterInstances(this IUnityContainer container)
        {
            return container;
        }
    }
}