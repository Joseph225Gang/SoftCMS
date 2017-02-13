using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoftCMS.Startup))]
namespace SoftCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
