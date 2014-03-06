using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TexasList.Startup))]
namespace TexasList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
