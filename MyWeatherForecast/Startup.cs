using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWeatherForecast.Startup))]
namespace MyWeatherForecast
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
