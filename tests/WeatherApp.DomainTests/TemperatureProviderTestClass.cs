using FluentAssertions;
using NUnit.Framework;
using WeatherApp.Domain.Provider;

namespace WeatherApp.DomainTests
{
    [TestFixture]
    public class TemperatureProviderTestClass
    {
        [Test]
        [TestCase(3,37.4)]
        [TestCase(7, 44.6)]
        [TestCase(13, 55.4)]
        [TestCase(23, 73.4)]
        [TestCase(35, 95)]
        [TestCase(38, 100.4)]
        [TestCase(59, 138.2)]
        public void CheckConvertCelciusToFahrenheit(double celcius, double fahrenheit)
        {
            double temp = TemperatureProvider.ConvertCelsiusToFahrenheit(celcius);
            temp.Should().Be(fahrenheit);
        }

        [Test]
        [TestCase(0, -17.78)]
        [TestCase(10, -12.22)]
        [TestCase(17, -8.33)]
        [TestCase(24, -4.44)]
        [TestCase(37, 2.78)]
        [TestCase(43, 6.11)]
        [TestCase(59, 15)]
        public void CheckFahrenheitToCelcius(double fahrenheit, double celcius)
        {
            double temp = TemperatureProvider.ConvertFahrenheitToCelsius(fahrenheit);
            temp.Should().Be(celcius);
        }
    }
}
