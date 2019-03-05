using RestServices.Domain.Contracts;
using RestWeather.Models;

namespace RestWeather.Domain
{
    public class WeatherRestService: IWeatherRestService
    {
        public WeatherReport GetWeatherReport(string cityName)
        {
            throw new System.NotImplementedException();
        }
    }
}
