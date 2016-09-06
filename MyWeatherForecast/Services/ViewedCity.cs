using System;
using System.Linq;
using System.Web;

namespace MyWeatherForecast.Services
{
    public class ViewedCity: ICookieManager
    {
        private readonly HttpContextBase _contextBase;
        private readonly HttpCookie _cities;


        public ViewedCity(HttpContext context)
        {
            _contextBase = new HttpContextWrapper(context);
            _cities = _contextBase.Request.Cookies["cities"] ?? new HttpCookie("cities");
        }

        public ViewedCity(HttpContextBase contextBase)
        {
            _contextBase = contextBase;
            _cities = _contextBase.Request.Cookies["cities"] ?? new HttpCookie("cities");
        }

        public void Update(string cityName)
        {
            var id = GenerateId(cityName);
            _cities[id] = cityName;
            _cities.Expires = DateTime.Now.AddDays(1);
            LimitCities(5);

            _contextBase.Response.Cookies.Add(_cities);
        }

        private void LimitCities(int limit)
        {
            if (limit <= 0) return;

            while (_cities.Values.AllKeys.Length > limit)
            {
                var key = _cities.Values.AllKeys.FirstOrDefault();
                if (key != null)
                {
                    _cities.Values.Remove(key);
                }
            }
        }

        private static string GenerateId(string cityName)
        {
            return cityName.GetHashCode().ToString();
        }

    }
}
