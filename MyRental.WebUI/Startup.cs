using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyRental.WebUI.Startup))]
namespace MyRental.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
