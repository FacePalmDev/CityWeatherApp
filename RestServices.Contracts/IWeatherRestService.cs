using RestWeather.Models;

namespace RestServices.Domain.Contracts
{
    public interface IWeatherRestService
    {
        WeatherReport GetWeatherReport(string cityName);
    }
}