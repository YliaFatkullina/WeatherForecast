using NLog;

namespace MyWeatherForecast.ViewModels
{
    public abstract class WeatherForecast : IWeatherForecast
    {
        public string Id { get; set; }

        public string City { get; set; }

        public string ForecastProvider { get; set; }

        public string ImageUrl { get; set; }

        public string Temperature { get; set; }

        public string WindSpeed { get; set; }

        public string Humidity { get; set; }

        public string Pressure { get; set; }

        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public abstract bool Create(dynamic jsonResult);

    }
}
