using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTankApp.Services;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FishTankApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Whenever some type asks for ISensorDataService object, supply an instance of SensorDataService.
            // AddSingleton means every time ISensorDataService is requested, the same instance of SensorDataService 
            // is given.   
            services.AddSingleton<ISensorDataService, SensorDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            ILoggerFactory loggerFactory)
        {

            // This middleware makes sure our app is correctly invoked by IIS.
            app.UseIISPlatformHandler();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello World!\n");
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World again!");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
