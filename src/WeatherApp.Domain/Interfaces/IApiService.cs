namespace WeatherApp.Domain.Interfaces
{
    public interface IApiService : ITemperature, IWindSpeed
    {
        string ApiUrl { get; }
        string InputLocation { get; }
    }
}