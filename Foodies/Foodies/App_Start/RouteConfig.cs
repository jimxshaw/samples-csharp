using System.Web.Mvc;
using System.Web.Routing;

namespace Foodies
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // /Cuisine/french

            routes.MapRoute("Cuisine",
                "cuisine/{name}",
                new { controller = "Cuisine", action = "Search", name = "" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
