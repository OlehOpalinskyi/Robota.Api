using DryIoc;
using Robota.Data;
using DryIoc.WebApi;
using System.Web.Http;
using Robota.api.Contracts;
using Robota.api.Services;

namespace Robota.api.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterDependencyInjection(HttpConfiguration config)
        {
            var container = new Container();
            Configure(container).WithWebApi(config);
        }

        private static Container Configure(Container container)
        {
            container.RegisterInstance(new RobotaContext());

            container.Register<ICategoryRepo, CategoryRepo>(Reuse.Singleton);
            container.Register<IPersonRepo, PersonRepo>(Reuse.Singleton);

            return container;
        }
    }
}