using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConfigureSetting.Web.Startup))]
namespace ConfigureSetting.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
