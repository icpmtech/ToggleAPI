using Bussiness.ToggleManager;
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

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g.
            container.RegisterType<IToggleManager, ToggleManager>();
            container.RegisterType<IClientToggle, ClientToggle>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}