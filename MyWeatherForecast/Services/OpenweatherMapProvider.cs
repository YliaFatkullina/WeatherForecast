using System;
using System.Dynamic;
using System.Net;
using MyWeatherForecast.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;


namespace MyWeatherForecast.Services
{
    public class OpenweatherMapProvider: IWeatherProvider
    {
        private readonly string _name = "Openweathermap";
        private readonly string _apiKey = "ff07ec93914c4416499b90c32c9c7cbd";
        private string _url = @"http://api.openweathermap.org/data/2.5/forecast/daily?q={1}&units=metric&cnt=1&appid={0}";

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public string Name
        {
            get { return _name; }
        }

        public string ApiKey
        {
            get { return _apiKey; }
        }

        public IWeatherForecast GetForecast(string cityName)
        {
            _url = string.Format(_url, _apiKey, cityName);

            return GetForecastInternal(_url);
        }

        private static IWeatherForecast GetForecastInternal(string url)
        {
            WeatherForecast weatherForecast = null;
            using (var client = new WebClient())
            {
                try
                {
                    var json = client.DownloadString(url);

                    dynamic jsonResult = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());

                    if (jsonResult.cod.ToString() == "404")
                        return null;

                    weatherForecast = new Openweathermap();
                    if (!weatherForecast.Create(jsonResult))
                        return null;

                }
                catch (Exception ex)
                {
                    Logger.Error("\r\n{0}\r\n{1}", ex.Message, ex.StackTrace);
                }
            }
            return weatherForecast;
        }
    }
}