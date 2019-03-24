using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoE.Quota.Web.Startup))]
namespace DoE.Quota.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
