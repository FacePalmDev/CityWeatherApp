using System.Collections.Generic;
using CityWeather.Data.Models.Dtos;

namespace CityWeather.Data.Contracts.Services
{
    public interface ICityDataService
    {
        void CreateCity(CityDto newCity);
        IEnumerable<CityDto> GetCities();
    }
}
