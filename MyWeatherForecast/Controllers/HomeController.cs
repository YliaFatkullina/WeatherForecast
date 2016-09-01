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
        private readonly IForecasts _forecasts;

        public HomeController(IForecasts forecasts)
        {
            _forecasts = forecasts;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetWeatherForecast(string cityName)
        {
            if(cityName != null)
            {
                return PartialView("WeatherForecast", SearchCity(cityName.Trim()));
            }
            return PartialView("WeatherForecast");
        }

        private IDictionary<string, IWeatherForecast> SearchCity(string cityName)
        {
            ViewData["city"] = cityName;

            var forecasts = _forecasts.GetForecasts(cityName);

            if (forecasts.Count > 0)
            {
                var firstOrDefault = forecasts.Values.FirstOrDefault();
                if (firstOrDefault != null)
                    AddCityInCookie(firstOrDefault.Id , cityName);
            }

            return forecasts;
        }

        private void AddCityInCookie(string id, string cityName)
        {
            var citiesCookie = Request.Cookies["cities"] ?? new HttpCookie("cities");
            citiesCookie[id] = cityName;
            citiesCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(citiesCookie);
        }

    }
}