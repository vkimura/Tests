using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_SocialAuth.Startup))]
namespace Test_SocialAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
