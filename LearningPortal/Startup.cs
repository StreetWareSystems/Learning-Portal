using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningPortal.Startup))]
namespace LearningPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
