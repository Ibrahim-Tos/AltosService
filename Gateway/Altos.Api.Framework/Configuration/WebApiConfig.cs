using System.Web.Http;

namespace Altos.Api.Framework.Configuration
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Initialize()
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            return config;
        }
    }
}
