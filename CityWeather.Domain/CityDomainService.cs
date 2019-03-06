using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models.Dtos;
using CityWeather.Domain.Contracts;
using CityWeather.Domain.Models;

namespace CityWeather.Domain
{
    public class CityDomainService: ICityDomainService
    {
        private readonly IMapperService _mapperService;
        private readonly ICityDataService _cityDataService;

        public CityDomainService(IMapperService mapperService, ICityDataService cityDataService)
        {
            _mapperService = mapperService;
            _cityDataService = cityDataService;
        }

        public void CreateCity(CityDomainModel newCityDomainModel)
        {
            var cityDtoModel = _mapperService.Map<CityDto>(newCityDomainModel);
            _cityDataService.CreateCity(cityDtoModel);
        }

        public void UpdateCity(int id, CityDomainModel city)
        {
            var cityDtoModel = _mapperService.Map<CityDto>(city);
            _cityDataService.UpdateCity(id, cityDtoModel);
        }

        public void DeleteCity(int id)
        {
            _cityDataService.DeleteCity(id);
        }
    }
}