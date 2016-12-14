using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Domain.Interfaces;

namespace WeatherApp.Domain.Provider
{
    public class WeatherProvider : IWeatherProvider
    {
        private IList<IApiService> _apiServices;

        public IList<string> Errors { get; }

        public WeatherProvider(IList<IApiService> apiServices)
        {
            _apiServices = apiServices;
            Errors = new List<string>();
        }
        public double GetAggregateFahrenheit() => Math.Round(_apiServices.Average(api => api.Fahrenheit), 2);
        public double GetAggregateCelsius() => Math.Round(_apiServices.Average(api => api.Celsius), 2);
        public double GetAggregateKph() => Math.Round(_apiServices.Average(api => api.Kph) , 1); 
        public double GetAggregateMph() => Math.Round(_apiServices.Average(api => api.Mph), 1);

        public async Task PostToApis()
        {
            var apiResponses = new List<IApiService>();
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(20);
                foreach (var api in _apiServices)
                {
                    try
                    {
                        string response = await httpClient.GetStringAsync(api.ApiUrl + api.InputLocation);
                        apiResponses.Add(JsonConvert.DeserializeObject(response, api.GetType()) as IApiService);
                    }
                    catch (TaskCanceledException)
                    {
                        Errors.Add($"Possible issue with API '{api.GetType().Name}' as no results returned");
                    }
                    catch (Exception)
                    {
                        Errors.Add("There has been a problem, please contact system administration");
                    }
                }
                _apiServices = apiResponses;
            }
        }
    }
}
