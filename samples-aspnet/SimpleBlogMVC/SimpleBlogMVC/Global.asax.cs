using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleBlogMVC.App_Start;

namespace SimpleBlogMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Utilizing the class from BundleConfig.cs.
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.Configure();
        }

        protected void Application_BeginRequest()
        {
            Database.OpenSession();
        }

        protected void Application_EndRequest()
        {
            Database.CloseSession();
        }
    }
}
