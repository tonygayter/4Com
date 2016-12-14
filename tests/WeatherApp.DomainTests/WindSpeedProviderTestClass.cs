using FluentAssertions;
using NUnit.Framework;
using WeatherApp.Domain.Provider;

namespace WeatherApp.DomainTests
{
    [TestFixture]
    public class WindSpeedProviderTestClass
    {
        [Test]
        [TestCase(0,0)]
        [TestCase(13, 20.92)]
        [TestCase(24, 38.62)]
        [TestCase(51, 82.08)]
        [TestCase(57, 91.73)]
        public void CheckConvertMphToKph(double mph, double kph)
        {
            double temp = WindSpeedProvider.ConvertMphToKph(mph);
            temp.Should().Be(kph);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(3, 1.86)]
        [TestCase(12, 7.46)]
        [TestCase(53, 32.93)]
        [TestCase(82, 50.95)]
        [TestCase(91,56.54)]
        [TestCase(108, 67.11)]
        public void CheckConvertKphToMph(double kph, double mph)
        {
            double temp = WindSpeedProvider.ConvertKphToMph(kph);
            temp.Should().Be(mph);
        }
    }
}
