using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TankStudios.Startup))]
namespace TankStudios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
