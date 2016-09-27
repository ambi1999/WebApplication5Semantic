using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication5Semantic.Startup))]
namespace WebApplication5Semantic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
