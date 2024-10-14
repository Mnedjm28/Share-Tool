using Microsoft.Owin;
using Owin;
using System.Runtime.InteropServices;

[assembly: OwinStartupAttribute(typeof(ShareTool.Startup))]
namespace ShareTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}