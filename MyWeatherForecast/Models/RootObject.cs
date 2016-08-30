using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherForecast.Models
{
    public class Features
    {
        public int forecast { get; set; }
    }

    public class Result
    {
        public string name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string country_iso3166 { get; set; }
        public string country_name { get; set; }
        public string zmw { get; set; }
        public string l { get; set; }
    }

    public class Response
    {
        public string version { get; set; }
        public string termsofService { get; set; }
        public Features features { get; set; }
        public List<Result> results { get; set; }
    }

    public class RootObject
    {
        public Response response { get; set; }
    }
}
