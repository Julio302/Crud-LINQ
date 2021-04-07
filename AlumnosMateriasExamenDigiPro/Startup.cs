using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlumnosMateriasExamenDigiPro.Startup))]
namespace AlumnosMateriasExamenDigiPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
