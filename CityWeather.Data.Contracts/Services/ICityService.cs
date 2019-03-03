using CityWeather.Data.Models.Dtos;

namespace CityWeather.Data.Contracts.Services
{
    public interface ICityService
    {
        void CreateCity(CityDto newCity);
    }
}
