using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Globalization.Startup))]
namespace Globalization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
