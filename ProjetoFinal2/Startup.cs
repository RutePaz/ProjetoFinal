using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoFinal2.Startup))]
namespace ProjetoFinal2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
