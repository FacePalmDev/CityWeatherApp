using CityWeather.Domain.Models;

namespace CityWeather.Domain.Contracts
{
    public interface ICityDomainService
    {
        void CreateCity(CityDomainModel newCityApiModel);
    }
}