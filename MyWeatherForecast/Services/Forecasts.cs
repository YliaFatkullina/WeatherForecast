using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeatherForecast.ViewModels;

namespace MyWeatherForecast.Services
{
    public class Forecasts : IForecasts
    {
        private readonly IWeatherService _weatherService;

        public Forecasts(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IDictionary<string, IWeatherForecast> GetForecasts(string cityName)
        {
            IDictionary<string, IWeatherForecast> forecasts = new Dictionary<string, IWeatherForecast>();

            foreach (var provider in _weatherService.Providers)
            {
                var forecast = provider.Value.GetForecast(cityName);
                if (forecast != null)
                    forecasts.Add(provider.Key, forecast);
            }
            return forecasts;
        }

    }
}