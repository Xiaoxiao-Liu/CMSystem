using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMSystem.Startup))]
namespace CMSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
