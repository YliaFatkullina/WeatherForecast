using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeatherForecast.ViewModels;

namespace MyWeatherForecast.Services
{
    public interface IForecasts
    {
        IDictionary<string, IWeatherForecast> GetForecasts(string cityName);

    }
}
