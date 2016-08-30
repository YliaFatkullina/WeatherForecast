using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace MyWeatherForecast.Models
{
    public abstract class Weather : IWeatherModel
    {
        public string Id { get; set; }

        public string City { get; set; }

        public string ForecastProvider { get; set; }

        public string ImageUrl { get; set; }

        public string Temperature { get; set; }

        public string WindSpeed { get; set; }

        public string Humidity { get; set; }

        public string Pressure { get; set; }

        public abstract void Create(dynamic json);

        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    }
}
