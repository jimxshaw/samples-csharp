using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetHub.Startup))]
namespace MeetHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
