using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models.Dtos;
using CityWeather.Domain.Contracts;
using CityWeather.Domain.Models;

namespace CityWeather.Domain
{
    public class CityDomainService: ICityDomainService
    {
        private readonly IMapperService _mapperService;
        private readonly Data.Contracts.Services.ICityService _cityService;

        public CityDomainService(IMapperService mapperService, Data.Contracts.Services.ICityService cityService)
        {
            _mapperService = mapperService;
            _cityService = cityService;
        }

        public void CreateCity(CityDomainModel newCityDomainModel)
        {
            var cityDtoModel = _mapperService.Map<CityDto>(newCityDomainModel);
            _cityService.CreateCity(cityDtoModel);
        }
    }
}