using System;

namespace WeatherApp.Domain.Provider
{
    public static class WindSpeedProvider
    {
        public static double ConvertMphToKph(double windSpeed)
        {
            return Math.Round(windSpeed * 1.609344, 2);
        }

        public static double ConvertKphToMph(double windSpeed)
        {
            return Math.Round(windSpeed * 0.621371192,2);
        }
    }
}
