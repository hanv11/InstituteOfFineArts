using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InstituteOfFineArts.Startup))]
namespace InstituteOfFineArts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
