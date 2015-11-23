using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeopleEntity.Startup))]
namespace PeopleEntity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
