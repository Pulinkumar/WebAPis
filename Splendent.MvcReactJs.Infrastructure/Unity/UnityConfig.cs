using Microsoft.Practices.Unity;
using Splendent.Framework.ServiceAgent;
using Splendent.MVCReactJS.Services.RestClients;
using Splendent.MVCReactJS.UIServices.Employee;
using Splendent.MVCReactJS.UIServices.Interface;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Filters;

namespace Splendent.Framework.Infrastructure.Unity
{
    /// <summary>
    /// UnityConfig
    /// </summary>
    public static class UnityConfig
    {
        public static UnityContainer _container;

        /// <summary>
        /// Register the Types
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            _container = new UnityContainer();

            RegisterTypes(_container);
            config.DependencyResolver = new UnityDependencyResolver(_container);
            RegisterWebApiControllerResolver(config, _container);
        }

        private static void RegisterWebApiControllerResolver(HttpConfiguration config, UnityContainer container)
        {
            config.Services.Replace(typeof(IHttpControllerActivator), new UnityWebApiControllerActivator(container));
        }

        private static void RegisterFilterProviders()
        {
            var providers = System.Web.Http.GlobalConfiguration.Configuration.Services.GetFilterProviders().ToList();

            GlobalConfiguration.Configuration.Services.Add(
                typeof(System.Web.Http.Filters.IFilterProvider),
                new UnityActionFilterProvider(_container));

            var defaultprovider = providers.First(p => p is ActionDescriptorFilterProvider);

            GlobalConfiguration.Configuration.Services.Remove(
                typeof(System.Web.Http.Filters.IFilterProvider),
                defaultprovider);
        }

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        public static void RegisterTypes(IUnityContainer container)
        {
            var builder = new ServiceAgentTypeBuilder();
            // Todo: Need to inject through Unity

            //ex.
            string endpoint = @"http://www.splendent.services.com/Splendent.Master.Api/";

            //Service Clients
            //ex.
            var employeeClient = builder.GetDynamicRestClientType<IEmployeeClient>(endpoint);
            container.RegisterInstance(employeeClient);

            //UI Service
            //ex.
            container.RegisterType<IEmployeeUiService, EmployeeUiService>(new TransientLifetimeManager());
        }
    }
}