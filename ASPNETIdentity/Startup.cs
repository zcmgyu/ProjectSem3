using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETIdentity.Startup))]
namespace ASPNETIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
