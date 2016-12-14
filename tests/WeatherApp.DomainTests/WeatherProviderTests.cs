using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using WeatherApp.Domain.Interfaces;
using WeatherApp.Domain.Provider;
using WeatherApp.Domain.Services;

namespace WeatherApp.DomainTests
{
    [TestFixture]
    public class WeatherProviderTests
    {
        private IList<IApiService> apis;
        private IWeatherProvider apiServices;

        [SetUp]
        public void Init()
        {
            apis = new List<IApiService>
            {
                new AccWeather {TemperatureFahrenheit = 68, WindSpeedMph = 10 },
                new BbcWeather {TemperatureCelsius = 10, WindSpeedKph = 8 }
            };

            apiServices = new WeatherProvider(apis) ;
        }

        [Test]
        public void CheckCorrectAggregatedFahrenheitTemperature()
        {
            apiServices.GetAggregateFahrenheit().Should().Be(59);
        }

        [Test]
        public void CheckCorrectAggregatedCelciusTemperature()
        {
           apiServices.GetAggregateCelsius().Should().Be(15);
        }

        [Test]
        public void CheckCorrectAggregatedMph()
        {
            apiServices.GetAggregateMph().Should().Be(7.5);
        }

        [Test]
        public void CheckCorrectAggregatedKph()
        {
            apiServices.GetAggregateKph().Should().Be(12);
        }
    }
}
