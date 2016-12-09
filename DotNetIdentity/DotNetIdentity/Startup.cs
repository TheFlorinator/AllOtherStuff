using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetIdentity.Startup))]
namespace DotNetIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
