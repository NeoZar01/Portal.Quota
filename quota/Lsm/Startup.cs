using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lsm.Startup))]
namespace Lsm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
