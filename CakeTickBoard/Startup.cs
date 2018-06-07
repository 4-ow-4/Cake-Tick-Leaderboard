using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CakeTickBoard.Startup))]
namespace CakeTickBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
