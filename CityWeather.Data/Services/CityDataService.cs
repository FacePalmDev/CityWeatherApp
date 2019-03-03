﻿using CityWeather.Data.Contracts;
using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models;
using CityWeather.Data.Models.Dtos;

namespace CityWeather.Data.Services
{
    public class CityDataService: ICityService
    {
        private readonly IRepository<City> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperService _mapperService;

        public CityDataService(IRepository<City> repository, IUnitOfWork unitOfWork, IMapperService mapperService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapperService = mapperService;
        }
 
        public void CreateCity(CityDto newCity)
        {
            var cityEntity = _mapperService.Map<City>(newCity);

            _repository.Create(cityEntity);
            _unitOfWork.Complete();
        }
    }
}