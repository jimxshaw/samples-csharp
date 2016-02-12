using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using ShipmentsAPI;

// This is the Owin startup class that will be fired when the server starts.
// The assembly attribute states that this'll be the class to be fired on startup.
[assembly: OwinStartup(typeof(Startup))]
namespace ShipmentsAPI
{
    public partial class Startup
    {
        // The IAppBuilder parameter is an interface, which will be used to compose the 
        // application for our Owin server. 
        public void Configuration(IAppBuilder app)
        {
            // The HttpConfiguration object will be used to configure our api routes. 
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            ConfigureAuthZero(app);

            // AllowAll is not recommended for production versions but since this is 
            // for development we'll allow all origins to call our api.  
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }

}