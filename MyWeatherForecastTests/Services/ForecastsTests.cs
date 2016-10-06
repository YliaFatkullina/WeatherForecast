using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWeatherForecast.Services;

namespace MyWeatherForecastTests.Services
{
    [TestClass]
    public class ForecastsTests
    {
        private readonly IWeatherService _weatherService;

        public ForecastsTests()
        {
            _weatherService = new WeatherService();
        }

        [TestMethod]
        public void TestCountWeatherService()
        {
            var cityName = "Москва";
            IForecasts forecasts = new Forecasts(_weatherService);

            var result = forecasts.GetForecasts(cityName);

            Assert.AreEqual(_weatherService.Providers.Count, result.Count);
        }

        [TestMethod]
        public void TestInvalidCityName()
        {
            var cityName = "епирнгот";
            IForecasts forecasts = new Forecasts(_weatherService);

            var result = forecasts.GetForecasts(cityName);

            Assert.AreEqual(0, result.Count);
        }

    }
}
