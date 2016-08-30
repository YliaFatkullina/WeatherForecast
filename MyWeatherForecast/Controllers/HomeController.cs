using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MyWeatherForecast.Models;
using MyWeatherForecast.Services;

namespace MyWeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string cityName)
        {
            Weather test = null;
            List<IWeatherModel> weathers = new List<IWeatherModel>();

            if (cityName != null)
            {
                ViewData["city"] = cityName;

                string citId = "";
                IWeatherService owm = new OpenweathermapService();
                IWeatherModel weatherForecast = owm.GetForecast(cityName.Trim());
                if (weatherForecast != null)
                {
                    weathers.Add(weatherForecast);
                    citId = weatherForecast.Id;
                }
                    
                IWeatherService wg = new WundergroundService();
                IWeatherModel weatherData = wg.GetForecast(cityName.Trim());
                if (weatherData != null)
                    weathers.Add(weatherData);

                var citiesCookie = Request.Cookies["cities"] ?? new HttpCookie("cities");
                
                citiesCookie[citId] = cityName;
                citiesCookie.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Add(citiesCookie);
            }
            return View(weathers);
        }

    }
}