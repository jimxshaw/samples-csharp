using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Foodies
{
    public class MvcApplication : System.Web.HttpApplication
    {
        // This class is used to hook up to application level events like Application_Start.
        // This method is invoked prior to invoking the first http request. All the code here 
        // will execute one time before any of our controllers execute. Code used for configuration 
        // is placed here. 
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
