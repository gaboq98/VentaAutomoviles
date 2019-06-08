using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VentaAutomoviles.Startup))]
namespace VentaAutomoviles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
