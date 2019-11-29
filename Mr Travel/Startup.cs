using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mr_Travel.Startup))]
namespace Mr_Travel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
