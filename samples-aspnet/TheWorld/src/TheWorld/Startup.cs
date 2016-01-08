using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheWorld.Services;
using Microsoft.Extensions.PlatformAbstractions;
using TheWorld.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using TheWorld.ViewModels;

namespace TheWorld
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                // Set the base path first so that our app will know where 
                // to find the below config.json file.
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            // This will take the configuration info from the environment variables and
            // give us a dictionary of name-value pairs that we can use. 
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                // It's unsafe to login with a username and password through HTTP because
                // others can intercept the credentials. The following filter option
                // redirects you to HTTPS. This will work for the entire site.
#if !DEBUG
                //config.Filters.Add(new RequireHttpsAttribute());
#endif
            })
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            // AddIdentity takes an options object that allows us to configure the
            // rules we want. The EF with WorldContext simply tells where to store
            // the identity items.
            services.AddIdentity<WorldUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                // We're using cookies. This cookie LoginPath method
                // will redirect to a particular location those who
                // are not authenticated and we asked them to be authenticated.
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";

                // Prevents unauthorized access when issuing API requests.
                // If the below works correct, the HTTP status should return 401 Unauthorized
                // as opposed to prevously, 200 OK.
                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                                ctx.Response.StatusCode == (int)HttpStatusCode.OK)
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }

                        return Task.FromResult(0);
                    }
                };
            })
                .AddEntityFrameworkStores<WorldContext>();

            services.AddLogging();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<WorldContext>();

            services.AddScoped<CoordinateService>();

            // Add transient always guarantees a new instance of this class.
            // The class gets passed in, gets used and then destroyed. It's not
            // hanging around for re-use.
            services.AddTransient<WorldContextSeedData>();

            services.AddScoped<IWorldRepository, WorldRepository>();

            // By creating the scoped service, it allows the AppController to get an
            // instance of the mail service through DebugMailService (which implements
            // the IMailService interface).
            services.AddScoped<IMailService, DebugMailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, WorldContextSeedData seeder, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug(LogLevel.Warning);

            app.UseStaticFiles();

            // The order sequence of these runtime method MATTER. 
            // First, the app checks for static files. Next, it checks for
            // identity and MVC.
            app.UseIdentity();

            // This allows for all the configuration among types.
            Mapper.Initialize(config =>
            {
                // I want to go from Trip to VM and do the reverse as well.
                config.CreateMap<Trip, TripViewModel>().ReverseMap();

                config.CreateMap<Stop, StopViewModel>().ReverseMap();
            });

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                );
            });

            await seeder.EnsureSeedDataAsync();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
