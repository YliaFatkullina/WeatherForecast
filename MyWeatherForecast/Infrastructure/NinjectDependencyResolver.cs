using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeatherForecast.Services;
using MyWeatherForecast.ViewModels;
using Ninject;

namespace MyWeatherForecast.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IWeatherProviders>().To<WeatherProviders>();
            _kernel.Bind<IWeatherForecast>().To<Openweathermap>();
            _kernel.Bind<IWeatherForecast>().To<Wunderground>();
        }
    }
}