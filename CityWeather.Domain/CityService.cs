using CityWeather.Api.Models;
using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models.Dtos;
using CityWeather.Domain;
using ICityService = CityWeather.Domain.Contracts.ICityService;

namespace CityWeather.Domain
{
    public class CityService: ICityService
    {
        private readonly IMapperService _mapperService;
        private readonly Data.Contracts.Services.ICityService _cityService;

        public CityService(IMapperService mapperService, Data.Contracts.Services.ICityService cityService)
        {
            _mapperService = mapperService;
            _cityService = cityService;
        }

        public void CreateCity(City newCity)
        {
            var cityDto = _mapperService.Map<CityDto>(newCity);
            _cityService.CreateCity(cityDto);
        }
    }
}