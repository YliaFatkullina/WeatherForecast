using System;
using System.Dynamic;
using System.Net;
using MyWeatherForecast.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;

namespace MyWeatherForecast.Services
{
    public class OpenweathermapService : IWeatherService
    {
        private readonly string _apiKey = "ff07ec93914c4416499b90c32c9c7cbd";
        private string _url = @"http://api.openweathermap.org/data/2.5/forecast/daily?q={1}&units=metric&cnt=1&appid={0}";
        
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public string ApiKey
        {
            get { return _apiKey; }
        }

        public IWeatherModel GetForecast(string cityName)
        {
            _url = string.Format(_url, _apiKey, cityName);

            return GetForecastInternal(_url);
        }

        private static IWeatherModel GetForecastInternal(string url)
        {
            Weather weather = null;
            using (var client = new WebClient())
            {
                try
                {
                    var json = client.DownloadString(url);

                    dynamic jsonResult = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());

                    if (jsonResult.cod.ToString() == "404")
                        return null;

                    weather = new Openweathermap();
                    weather.Create(jsonResult);

                }
                catch(Exception ex)
                {
                    Logger.Error("\r\n{0}\r\n{1}", ex.Message, ex.StackTrace);
                }
            }
            return weather;
        }
    }
}