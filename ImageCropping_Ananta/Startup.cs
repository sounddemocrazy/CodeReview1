using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageCropping_Ananta.Startup))]
namespace ImageCropping_Ananta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
