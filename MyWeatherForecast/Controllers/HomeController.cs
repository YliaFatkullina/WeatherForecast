using System;
using System.Collections.Generic;
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

        private List<IWeatherModel> SearchCity(string cityName)
        {
            
            ViewData["city"] = cityName;

            List<IWeatherModel> weathers = new List<IWeatherModel>();
            string citId = "";
            IWeatherService owm = new OpenweathermapService();
            IWeatherModel weatherForecast = owm.GetForecast(cityName);
            if (weatherForecast != null)
            {
                weathers.Add(weatherForecast);
                citId = weatherForecast.Id;
            }

            IWeatherService wg = new WundergroundService();
            IWeatherModel weatherData = wg.GetForecast(cityName);
            if (weatherData != null)
                weathers.Add(weatherData);

            if (weathers.Count != 0)
            {
                var citiesCookie = Request.Cookies["cities"] ?? new HttpCookie("cities");
                citiesCookie[citId] = cityName;
                citiesCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(citiesCookie);
            }
            
            return weathers;
        }

    }
}