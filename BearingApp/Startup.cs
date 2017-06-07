using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BearingApp.Startup))]
namespace BearingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
