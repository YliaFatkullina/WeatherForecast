﻿using System;

namespace MyWeatherForecast.Models
{
    public class WundergroundWeather : Weather
    {
        private readonly string _forecastProvider = "WunderGround.com";

        public override void Create(dynamic json)
        {
            try
            {
                ForecastProvider = _forecastProvider;
                Id = json.current_observation.station_id.ToString();
                City = json.current_observation.display_location.city.ToString();
                Pressure = json.current_observation.pressure_mb.ToString();
                Humidity = json.current_observation.relative_humidity.ToString();
                WindSpeed = json.current_observation.wind_mph.ToString();
                Temperature = json.current_observation.temp_c.ToString();
                ImageUrl = json.current_observation.icon_url.ToString();
            }
            catch (Exception ex)
            {
                Logger.Error("\r\n{0}\r\n{1}", ex.Message, ex.StackTrace);
            }
        }
    }
}