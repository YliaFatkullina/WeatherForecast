using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherForecast.Services
{
    public interface IWeatherProviders
    {
        IDictionary<string, IWeatherProvider> Providers { get; set; }
    }
}
