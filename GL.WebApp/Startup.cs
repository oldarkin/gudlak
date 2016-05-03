using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GL.WebApp.Startup))]
namespace GL.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
