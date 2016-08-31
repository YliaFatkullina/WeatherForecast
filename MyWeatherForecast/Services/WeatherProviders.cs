using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherForecast.Services
{
    public class WeatherProviders : IWeatherProviders
    {
        private IDictionary<string, IWeatherProvider> _providers = new Dictionary<string, IWeatherProvider>
        {
            {"Openweathermap", new OpenweatherMapProvider()},
            {"WunderGround", new WundergroundProvider()}
        };


        public IDictionary<string, IWeatherProvider> Providers
        {
            get { return _providers; }
            set { _providers = value; }
        }

        public void Add(string providerName, IWeatherProvider provider)
        {
            _providers.Add(providerName, provider);
        }
    }
}
