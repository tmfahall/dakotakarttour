using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DKTFinal.Startup))]
namespace DKTFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
