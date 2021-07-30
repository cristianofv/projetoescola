using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ensino.Web.Startup))]
namespace Ensino.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
