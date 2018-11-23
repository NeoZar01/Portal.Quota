using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoE.Lsm.Web.Startup))]
namespace DoE.Lsm.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
