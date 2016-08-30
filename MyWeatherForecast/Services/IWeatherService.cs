using System.Web;
using MyWeatherForecast.Models;

namespace MyWeatherForecast.Services
{
    public interface IWeatherService
    {
        string ApiKey { get; }

        IWeatherModel GetForecast(string cityName);

        //void GetForecast(HttpCookie citiesCookie);
    }
}
