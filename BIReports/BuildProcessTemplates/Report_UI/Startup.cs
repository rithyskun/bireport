using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Report_UI.Startup))]
namespace Report_UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
