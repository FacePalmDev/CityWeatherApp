using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models.Dtos;
using CityWeather.Domain.Contracts;
using CityWeather.Domain.Models;
using CityWeather.Domain.Validators;
using FluentValidation;

namespace CityWeather.Domain
{
    public class CityDomainService: ICityDomainService
    {
        private readonly IMapperService _mapperService;
        private readonly ICityDataService _cityDataService;
        private readonly CityDomainModelValidator _cityDomainModelValidator;

        public CityDomainService(IMapperService mapperService, ICityDataService cityDataService, CityDomainModelValidator cityDomainModelValidator)
        {
            _mapperService = mapperService;
            _cityDataService = cityDataService;
            _cityDomainModelValidator = cityDomainModelValidator;
        }

        public void CreateCity(CityDomainModel newCityDomainModel)
        {
            var validation = _cityDomainModelValidator.Validate(newCityDomainModel);
          
            if (validation.IsValid == false)
            {
                throw new ValidationException(validation.Errors);
            }
            
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