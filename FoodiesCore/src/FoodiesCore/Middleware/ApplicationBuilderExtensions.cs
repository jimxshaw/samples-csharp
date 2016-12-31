using System.IO;
using Microsoft.Extensions.FileProviders;

// It's common convention that any extension method that returns IApplicationBuilder
// be placed in the Microsoft.AspNetCore.Builder namespace. 
namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");

            // The path passed into the constructor must be an absolute path.
            var provider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = provider;


            app.UseStaticFiles(options);

            return app;
        }
    }
}
