using System;
using System.Net;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWeatherForecast.Controllers;
using MyWeatherForecast.Services;
using System.Web;
using System.Web.Mvc;

namespace MyWeatherForecastTests
{
    [TestClass]
    public class HomeControllerTests
    {
        private FakeHttpContext.FakeHttpContext _fakeHttpContext;

        [TestInitialize]
        public void Initialize()
        {
            _fakeHttpContext = new FakeHttpContext.FakeHttpContext();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _fakeHttpContext.Dispose();
        }

        [TestMethod]
        public void TestIndexViewModelNotNullMoq()
        {
            var forecasts = new Mock<IForecasts>();
            var cookieManager = new Mock<ICookieManager>();
            HomeController controller = new HomeController(forecasts.Object, cookieManager.Object);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestIndexViewModelNotNull()
        {
            var forecasts = new Mock<IForecasts>();
            var cookieManager = new Mock<ICookieManager>();
            HomeController controller = new HomeController(forecasts.Object, cookieManager.Object);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestPartialViewResultNotNullMoq()
        {
            var forecasts = new Mock<IForecasts>();
            var cookieManager = new Mock<ICookieManager>();
            HomeController controller = new HomeController(forecasts.Object, cookieManager.Object);

            PartialViewResult result = controller.GetWeatherForecast("Москва") as PartialViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestPartialViewResultNotNull()
        {
            var forecasts = new Mock<IForecasts>();
            var cookieManager = new Mock<ICookieManager>();
            HomeController controller = new HomeController(forecasts.Object, cookieManager.Object);

            PartialViewResult result = controller.GetWeatherForecast("Москва") as PartialViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestPartialViewResultName()
        {
            IWeatherService weatherService = new WeatherService();
            IForecasts forecasts = new Forecasts(weatherService);
            ICookieManager cookieManager = new ViewedCity(HttpContext.Current);
            HomeController controller = new HomeController(forecasts, cookieManager);

            PartialViewResult result = controller.GetWeatherForecast("Москва") as PartialViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("WeatherForecast", result.ViewName);
        }
    }
}
