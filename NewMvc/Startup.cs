using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewMvc.Startup))]
namespace NewMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
