using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GL.Web.Startup))]
namespace GL.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
