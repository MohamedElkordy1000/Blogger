using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blogging_system.Startup))]
namespace Blogging_system
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
