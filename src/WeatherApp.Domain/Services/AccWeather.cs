using WeatherApp.Domain.Interfaces;
using WeatherApp.Domain.Provider;

namespace WeatherApp.Domain.Services
{
    public class AccWeather : IApiService
    {
        public double TemperatureFahrenheit { get;  set; }
        public string Where { get; set; }
        public double WindSpeedMph { get; set; }
        public string ApiUrl => "http://localhost:60368/";
        public string InputLocation => Where;
        public double Kph => WindSpeedProvider.ConvertMphToKph(WindSpeedMph);
        public double Mph => WindSpeedMph;
        public double Fahrenheit => TemperatureFahrenheit;
        public double Celsius => TemperatureProvider.ConvertFahrenheitToCelsius(TemperatureFahrenheit);     
    }
}
