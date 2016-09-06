using System.Collections.Generic;
using System.Web.Mvc;
using MyWeatherForecast.Services;
using MyWeatherForecast.ViewModels;

namespace MyWeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private readonly IForecasts _forecasts;
        private readonly ICookieManager _cookie;

        public HomeController(IForecasts forecasts, ICookieManager cookie)
        {
            _forecasts = forecasts;
            _cookie = cookie;
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

            _cookie.Update(cityName);

            return forecasts;
        }

    }
}