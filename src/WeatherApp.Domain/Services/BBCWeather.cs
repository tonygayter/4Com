using WeatherApp.Domain.Interfaces;
using WeatherApp.Domain.Provider;

namespace WeatherApp.Domain.Services
{
    public class BbcWeather : IApiService
    {
        public string Location { get; set; }
        public double TemperatureCelsius { get; set; }
        public double WindSpeedKph { get; set; }
        public string ApiUrl => "http://localhost:60350/Weather/";
        public string InputLocation => Location;
        public double Mph => WindSpeedProvider.ConvertKphToMph(WindSpeedKph);
        public double Kph => WindSpeedKph;
        public double Fahrenheit =>TemperatureProvider.ConvertCelsiusToFahrenheit(TemperatureCelsius);
        public double Celsius => TemperatureCelsius;
    }
}
