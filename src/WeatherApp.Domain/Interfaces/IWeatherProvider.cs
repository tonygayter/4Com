using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApp.Domain.Interfaces
{
    public interface IWeatherProvider
    {
        IList<string> Errors { get; }
        double GetAggregateCelsius();
        double GetAggregateFahrenheit();
        double GetAggregateKph();
        double GetAggregateMph();
        Task PostToApis();
    }
}