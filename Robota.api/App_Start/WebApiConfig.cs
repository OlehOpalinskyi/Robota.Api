using DryIoc;
using DryIoc.WebApi;
using Robota.api.App_Start;
using Robota.Data;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Robota.api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();
            FormatConfig.Formatters(config);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        //private static HttpConfiguration ConfigureDependencyInjection(this HttpConfiguration config)
        //{
        //    var container = new Container();
        //    container.RegisterInstance(new RobotaContext());
        //    container.WithWebApi(config);
        //    return config;
        //}
    }
}
