using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        public Startup()
        {
            // The purpose of a configuration builder is so that we can use it to define configurable sources 
            // for our application. We can chain on different sources. 
            var builder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json");

            // Use the configuration property and build up the data structure that will represent the 
            // configuration that we'll need. 
            Configuration = builder.Build();
        }


        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // All services have to be registered.

            // Give a service provider and return a service that will be stored away for use. 
            services.AddSingleton(provider => Configuration);
            // Whenever something needs an implementation of IGreeter, please give it an instance of the 
            // Greeter class. 
            services.AddSingleton<IGreeter, Greeter>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                                IGreeter greeter)
        {
            app.UseIISPlatformHandler();

            app.Run(async (context) =>
            {
                var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
