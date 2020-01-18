using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoStoreManager.Startup))]
namespace VideoStoreManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
