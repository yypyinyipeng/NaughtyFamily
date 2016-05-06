using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NaughtyFamily.Startup))]
namespace NaughtyFamily
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
