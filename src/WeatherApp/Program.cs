using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WeatherApp.Domain.Interfaces;
using WeatherApp.Domain.Provider;
using WeatherApp.Domain.Services;

namespace WeatherApp
{
    public class Program
    {
        private static IWeatherProvider weatherProvider;
        private static string LocationInput { get; set; }
        public static void Main(string[] args)
        {
            PropertyInfo[] windSpeedTypes;
            PropertyInfo[] temperatureTypes;

            Console.WriteLine("Please enter location:");
            LocationInput = Console.ReadLine();
            SetupServices();
            
            var windOption = WindSpeedTypes(out windSpeedTypes);
            var temperatureOption = TemperatureTypes(out temperatureTypes);

            try
            {
                Console.WriteLine($"You selected {windSpeedTypes[int.Parse(windOption) - 1].Name} and {temperatureTypes[int.Parse(temperatureOption) - 1].Name}");
            }
            catch
            {
                Console.WriteLine("You made an invalid selection");
            }

            weatherProvider.PostToApis().Wait();

            Console.WriteLine($"In {LocationInput} the temperature and windspeed averages are:");
            switch (temperatureOption)
            {
                case "1":
                    Console.WriteLine($"{weatherProvider.GetAggregateFahrenheit()}\x00B0F");
                    break;
                case "2":
                    Console.WriteLine($"{weatherProvider.GetAggregateCelsius()}\x00B0C");
                    break;
                default:
                    Console.WriteLine($"Invalid temerature selection '{temperatureOption}'");
                    break;
            }
            switch (windOption)
            {
                case "1":
                    Console.WriteLine($"{weatherProvider.GetAggregateMph()}mph");
                    break;
                case "2":
                    Console.WriteLine($"KPH: {weatherProvider.GetAggregateKph()}kph");
                    break;
                default:
                    Console.WriteLine($"Invalid wind speed selection '{windOption}'");
                    break;
            }

            if (weatherProvider.Errors.Any())
            {
                foreach (var error in weatherProvider.Errors)
                {
                    Console.WriteLine(error);
                }
            }
            Console.ReadLine();
        }

        private static string TemperatureTypes(out PropertyInfo[] temperatureTypes)
        {
            temperatureTypes = typeof (ITemperature).GetProperties();
            var option = 1;
            Console.WriteLine("Please select temperature type from the following:");
            foreach (var type in temperatureTypes)
            {
                Console.WriteLine($"Press {option} for {type.Name}");
                option++;
            }
            string temperatureOption = Console.ReadLine();
            return temperatureOption;
        }

        private static string WindSpeedTypes(out PropertyInfo[] windSpeedTypes)
        {
            windSpeedTypes = typeof (IWindSpeed).GetProperties();
            int option = 1;
            Console.WriteLine("Please select from the following:");
            foreach (var type in windSpeedTypes)
            {
                Console.WriteLine($"Press {option} for {type.Name}");
                option++;
            }
            string windOption = Console.ReadLine();
            return windOption;
        }

        private static void SetupServices()
        {
            weatherProvider = new WeatherProvider(new List<IApiService>
            {
                new BbcWeather() { Location = LocationInput},
                new AccWeather() { Where = LocationInput }
            });
        }
    }
}
