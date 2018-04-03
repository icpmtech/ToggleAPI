using Bussiness.ToggleManager;
using Common.Infrastructure;

using Service.ClientToggle;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ToggleAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            
            container.RegisterType<IToggleManager, ToggleManager>();
            container.RegisterType<IClientToggle, ClientToggle>();
           container.RegisterType<ILoggerApi, Logger>();



            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}