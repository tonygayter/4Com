using System;

namespace WeatherApp.Domain.Provider
{
    public static class TemperatureProvider
    {
        public static double ConvertCelsiusToFahrenheit(double temperature)
        {
            return Math.Round(9.0/5.0*temperature + 32, 2);
        }

        public static double ConvertFahrenheitToCelsius(double temperature)
        {
            return Math.Round(5.0/9.0*(temperature - 32), 2);
        }
    }
}