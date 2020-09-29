using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameReviewer.WebMVC.Startup))]
namespace GameReviewer.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
