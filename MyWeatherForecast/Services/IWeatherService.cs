using System.Collections.Generic;

namespace MyWeatherForecast.Services
{
    public interface IWeatherService
    {
        IDictionary<string, IWeatherProvider> Providers { get; set; }
    }
}
