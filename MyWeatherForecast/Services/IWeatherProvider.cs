using MyWeatherForecast.ViewModels;

namespace MyWeatherForecast.Services
{
    public interface IWeatherProvider
    {
        string Name { get; }
        string ApiKey { get; }

        IWeatherForecast GetForecast(string cityName);
    }
}
