using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToDo.MVC.Startup))]
namespace ToDo.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
