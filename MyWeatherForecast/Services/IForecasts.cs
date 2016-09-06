using System.Collections.Generic;
using MyWeatherForecast.ViewModels;

namespace MyWeatherForecast.Services
{
    public interface IForecasts
    {
        IDictionary<string, IWeatherForecast> GetForecasts(string cityName);

    }
}
