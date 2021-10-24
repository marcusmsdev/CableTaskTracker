using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CableMVC.Startup))]
namespace CableMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
