[assembly: WebActivator.PostApplicationStartMethod(typeof(Montreal.NomeSistema.Services.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Montreal.NomeSistema.Services.App_Start
{
    using System.Reflection;

    using SimpleInjector;
    using Montreal.NomeSistema.Modulo1.Infra;
    using SimpleInjector.Integration.WebApi;
    using System.Web.Http;
    using SimpleInjector.Lifestyles;

    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration, Assembly.GetExecutingAssembly());

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            BootStrapperModulo1.Register(container);
        }
    }
}