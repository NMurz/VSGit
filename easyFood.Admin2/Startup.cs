using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(easyFood.Admin2.Startup))]
namespace easyFood.Admin2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
