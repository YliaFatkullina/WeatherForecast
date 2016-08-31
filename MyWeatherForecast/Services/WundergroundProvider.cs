using System;
using System.Dynamic;
using System.Net;
using System.Text;
using System.Web;
using MyWeatherForecast.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;

namespace MyWeatherForecast.Services
{
    public class WundergroundProvider : IWeatherProvider
    {
        private readonly string _name = "WunderGround";
        private readonly string _apiKey = "8fa8ff9308bb395e";
        private string _url = @"http://api.wunderground.com/api/{0}/conditions/lang:RU/q/CA/{1}.json";
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
            _url = string.Format(_url, _apiKey, FirstLetterToUpper(cityName));

            return GetForecastInternal(_url);
        }

        public static string FirstLetterToUpper(string str)
        {
            if (str.Length > 0)
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            return "";
        }

        private static IWeatherForecast GetForecastInternal(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            using (var client = new WebClient())
            {
                try
                {
                    var json = client.DownloadString(url);

                    dynamic jsonResult = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());

                    try
                    {
                        if (jsonResult.current_observation != null)
                        {
                            var weather = new Wunderground();
                            return weather.Create(jsonResult) ? weather : null;
                        }
                    }
                    catch
                    {
                        string zmw = GetZmw(jsonResult);
                        var newUrl = GetUrlWithZmw(url, zmw);
                        return GetForecastInternal(newUrl);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("\r\n{0}\r\n{1}", ex.Message, ex.StackTrace);
                    Logger.Info("\r\n{0}", url);
                }
            }
            return null;
        }

        private static string GetZmw(dynamic jsonResult)
        {
            foreach (var item in jsonResult.response.results)
            {
                if (item.country_iso3166 == "RU")
                {
                    return item.zmw.ToString();
                }
            }
            return null;
        }

        private static string GetUrlWithZmw(string url, string zmw)
        {
            return string.IsNullOrEmpty(zmw) ? null : url.Replace(url.Substring(69), "/zmw:" + zmw + ".json");
        }
    }
}
