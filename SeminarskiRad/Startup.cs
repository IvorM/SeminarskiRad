using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeminarskiRad.Startup))]
namespace SeminarskiRad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
