using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectSem3.Startup))]
namespace ProjectSem3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
