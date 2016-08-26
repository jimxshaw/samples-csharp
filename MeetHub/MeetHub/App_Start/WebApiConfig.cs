using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace MeetHub
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            // ASP.NET Web Api returns JSON in PascalCase by default but convention dictates that JSON 
            // be in camelCase when it's to be consumed by the client. 
            // We force camelCase by using GlobalConfiguration. 
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
