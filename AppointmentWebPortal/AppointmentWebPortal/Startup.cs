using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppointmentWebPortal.Startup))]
namespace AppointmentWebPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
