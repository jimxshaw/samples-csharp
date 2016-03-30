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

            // By adding the MVC service here, we'll get access everything asp.net needs to do MVC work.
            services.AddMvc();
            // Give a service provider and return a service that will be stored away for use. 
            services.AddSingleton(provider => Configuration);
            // Whenever something needs an implementation of IGreeter, please give it an instance of the 
            // Greeter class. 
            services.AddSingleton<IGreeter, Greeter>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                                IHostingEnvironment environment,
                                IGreeter greeter)
        {
            // Keep in mind that the order of which middlewares are installed matter. 

            // The IIS Platform middleware looks at every incoming request and see if there's any windows 
            // identity information associated with the request. 
            app.UseIISPlatformHandler();

            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRuntimeInfoPage("/info");

            ////  The Static Files middleware find files on the file system and serve up those files.If it
            ////  doesn't find a file, it will move on to the next piece of middleware.   
            //  app.UseStaticFiles();

            ////  What use default files middleware does is see if it's in a root directory and if it is 
            ////  then it looks to see if there are any default files.If we want we could overwrite by telling
            ////  it which files are the default files.For example, index.html is a default file by default.
            //  app.UseDefaultFiles();

            //app.UseFileServer();

            // The MVC middleware is usually placed after any other middleware that serves up static files. 
            // 
            app.UseMvcWithDefaultRoute();

            // The Run middleware allows us to pass in another method that processes every other response. 
            // Run is called a terminal piece of middleware. Run will not be able to call another piece of 
            // middleware. All it does is receive a request and produces a piece of response. Any other 
            // middleware called after Run will not run because Run is terminal. 
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
