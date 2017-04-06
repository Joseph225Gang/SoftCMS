using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoftCMS.Startup))]
namespace SoftCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
<<<<<<< HEAD
=======
            app.MapSignalR();
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
            ConfigureAuth(app);
        }
    }
}
