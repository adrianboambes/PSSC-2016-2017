using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityLocal.Startup))]
namespace UniversityLocal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
