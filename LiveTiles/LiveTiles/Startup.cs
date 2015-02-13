using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LiveTiles.Startup))]
namespace LiveTiles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
