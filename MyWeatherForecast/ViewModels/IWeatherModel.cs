namespace MyWeatherForecast.ViewModels
{
    public interface IWeatherModel
    {
        string Id { get; set; }

        string City { get; set; }

        string ForecastProvider { get; set; }

        string ImageUrl { get; set; }

        string Temperature { get; set; }

        string WindSpeed { get; set; }

        string Humidity { get; set; }

        string Pressure { get; set; }

        void Create(dynamic json);
    }
}
