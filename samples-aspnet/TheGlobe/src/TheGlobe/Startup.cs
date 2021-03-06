﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheGlobe.Models;
using TheGlobe.Services;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TheGlobe.ViewModels;

namespace TheGlobe
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton(_config);

            if (_env.IsDevelopment() || _env.IsEnvironment("Testing"))
            {
                // AddScoped means we'd like our service to be reused but only within the scope of a single request.
                // Other methods that could be used are AddTransient or AddSingleton.
                services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                // Implement a real Mail Service.
            }

            services.AddDbContext<GlobeContext>();

            services.AddScoped<IGlobeRepository, GlobeRepository>();

            services.AddTransient<GeoCoordinatesService>();

            services.AddTransient<GlobeContextSeedData>();

            services.AddIdentity<GlobeUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = async context =>
                    {
                        // When the status code is 200 OK and the path is api then we'll proceed by returning 
                        // the status code to be 401 Unauthorized.
                        if (context.Request.Path.StartsWithSegments("/api") && context.Response.StatusCode == 200)
                        {
                            context.Response.StatusCode = 401;
                        }
                        else
                        {
                            context.Response.Redirect(context.RedirectUri);
                        }
                        await Task.Yield();
                    }
                };
            })
            .AddEntityFrameworkStores<GlobeContext>();

            services.AddLogging();

            services.AddMvc(config =>
            {
                // This filter's purpose is for if we attempt to goto an Http,
                // it'll try to redirect us to Https. When credentials are sent
                // over the wire, they'll be protected with a certificate. Any 
                // site that accepts creditionals should use Https. 
                // We put a condition so that it occurs only when 
                // the environment is Production.
                if (_env.IsProduction())
                {
                    config.Filters.Add(new RequireHttpsAttribute());
                }
            })
                .AddJsonOptions(config =>
                {
                    config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            ILoggerFactory loggerFactory,
            GlobeContextSeedData seeder)
        {
            Mapper.Initialize(config => {
                // By using CreateMap, we're mapping from ViewModel to Model but in order 
                // to map back from model to ViewModel, we must call ReverseMap or an 
                // AutoMapper error will occur. This is called bi-directional mapping.
                // Even when our ViewModel or Model is inside 
                // an IEnumerable, for example, AutoMapper can map collection to collection.
                config.CreateMap<TripViewModel, Trip>().ReverseMap();
                config.CreateMap<StopViewModel, Stop>().ReverseMap();
            });

            loggerFactory.AddConsole();

            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug(LogLevel.Information);
            }
            else
            {
                loggerFactory.AddDebug(LogLevel.Error);
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new {controller = "App", action = "Index"});
            });

            seeder.EnsureSeedData().Wait();

        }
    }
}
