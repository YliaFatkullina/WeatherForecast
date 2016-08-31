using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeatherForecast.Services;
using MyWeatherForecast.ViewModels;

namespace MyWeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetWeatherForecast(string cityName)
        {
            if(cityName != null)
            {
                return PartialView("WeatherForecastPartial", SearchCity(cityName.Trim()));
            }
            return PartialView("WeatherForecastPartial");
        }

        private IDictionary<string, IWeatherForecast> SearchCity(string cityName)
        {
            ViewData["city"] = cityName;

            IWeatherProviders weatherService = new WeatherProviders();

            IDictionary<string, IWeatherForecast> forecasts = new Dictionary<string, IWeatherForecast>();

            foreach (var provider in weatherService.Providers)
            {
                var forecast = provider.Value.GetForecast(cityName);
                if (forecast != null)
                    forecasts.Add(provider.Key, forecast);
            }

            if (forecasts.Count != 0)
            {
                var citiesCookie = Request.Cookies["cities"] ?? new HttpCookie("cities");
                var firstOrDefault = forecasts.Values.FirstOrDefault();
                if (firstOrDefault != null)
                {
                    var id = firstOrDefault.Id;
                    citiesCookie[id] = cityName;
                }
                citiesCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(citiesCookie);
            }

            return forecasts;
        }
    }
}