using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTankApp.Options;
using FishTankApp.Services;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FishTankApp
{
    public class Startup
    {
        private IHostingEnvironment _hostingEnvironment;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // This will allow environment specific json files to override the default json file. Even so, it's
            // still allowed to be optional however. 
            var configBuilder = new ConfigurationBuilder()
                    .AddJsonFile("alertThresholds.json")
                    .AddJsonFile($"alertThresholds{_hostingEnvironment.EnvironmentName}.json", optional: true);

            var config = configBuilder.Build();

            // By writing the configure line below, a ThresholdOptions instance filled with settings from a json 
            // file will be available for injection. 
            services.Configure<ThresholdOptions>(config);

            services.AddMvc();

            services.AddSingleton<IViewModelService, ViewModelService>();

            // Whenever some type asks for ISensorDataService object, supply an instance of SensorDataService.
            // AddSingleton means every time ISensorDataService is requested, the same instance of SensorDataService 
            // is given.   
            services.AddSingleton<ISensorDataService, SensorDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            ILoggerFactory loggerFactory)
        {
            // The hosting environment can be found in a project's properties -> DEBUG or in launchSettings.json.
            if (_hostingEnvironment.IsDevelopment())
            {
                // The exception page is only shown if the app is in development mode.
                app.UseDeveloperExceptionPage();
            }

            // This middleware makes sure our app is correctly invoked by IIS.
            app.UseIISPlatformHandler();

            // Add the MVC middleware service above first. Then use said middleware in this method.
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action}/{id}",
            //        defaults: new { controller = "Home", action = "Index" }
            //    );
            //});

            app.UseMvcWithDefaultRoute();

            // Always remember to add the static files middleware or the images from JavaScript or CSS 
            // won't be served.
            app.UseStaticFiles();

            // Whenever HTTP status codes like 404 arise, the below middleware will display them on the page.
            app.UseStatusCodePages();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
