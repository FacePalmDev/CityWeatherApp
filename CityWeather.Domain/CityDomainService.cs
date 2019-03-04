using CityWeather.Common.Mappings;
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
    }
}