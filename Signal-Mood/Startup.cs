using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Signal_Mood.Startup))]
namespace Signal_Mood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
