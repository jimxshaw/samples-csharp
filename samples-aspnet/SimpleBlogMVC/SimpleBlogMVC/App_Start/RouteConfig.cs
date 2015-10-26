using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SimpleBlogMVC.Controllers;

namespace SimpleBlogMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Local variable of an array of strings that contains the namespace 
            // of wherever our PostsController namespace exists. When namespaces is
            // passed into the routes below, they'll be targeting a specific folder.
            // This is done to avoid conflicts as more than one PostsController exist.
            var namespaces = new[] { typeof(PostsController).Namespace };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Login", "login", new { controller = "Auth", action = "Login" }, namespaces);

            routes.MapRoute("Logout", "logout", new { controller = "Auth", action = "Logout" }, namespaces);

            routes.MapRoute("Home", "", new { controller = "Posts", action = "Index" }, namespaces);

            // The default route will not be used.
            // All routes in this application will be explicit, which
            // allows the developer to have more control.

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
