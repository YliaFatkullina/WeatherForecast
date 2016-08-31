using System;
using MyWeatherForecast.Services;

namespace MyWeatherForecast.ViewModels
{

    public class Openweathermap : WeatherForecast
    {
        private string imgPath = @"http://openweathermap.org/img/w/{0}.png";


        public override bool Create(dynamic jsonResult)
        {
            try
            {
                Id = jsonResult.city.id.ToString();
                City = jsonResult.city.name.ToString();
                Pressure = jsonResult.list[0].pressure.ToString();
                Humidity = jsonResult.list[0].humidity.ToString();
                WindSpeed = jsonResult.list[0].speed.ToString();
                Temperature = jsonResult.list[0].temp.day.ToString();
                ImageUrl = string.Format(imgPath, jsonResult.list[0].weather[0].icon.ToString());
            }
            catch (Exception ex)
            {
                Logger.Error("\r\n{0}\r\n{1}", ex.Message, ex.StackTrace);
                return false;
            }
            return true;
        }
    }
}
