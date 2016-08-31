using System.Web;
using MyWeatherForecast.ViewModels;

namespace MyWeatherForecast.Services
{
    public interface IWeatherService
    {
        string ApiKey { get; }

        IWeatherModel GetForecast(string cityName);

        //void GetForecast(HttpCookie citiesCookie);
    }
}
