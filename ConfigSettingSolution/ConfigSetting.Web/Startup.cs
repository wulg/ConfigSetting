using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConfigSetting.Web.Startup))]
namespace ConfigSetting.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
