using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aplikacja.Startup))]
namespace aplikacja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
