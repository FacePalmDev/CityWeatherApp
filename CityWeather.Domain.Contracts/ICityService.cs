using CityWeather.Api.Models;

namespace CityWeather.Domain.Contracts
{
    public interface ICityService
    {
        void CreateCity(City newCity);
    }
}