using System.Collections.Generic;
using System.Linq;
using CityWeather.Data.Contracts;
using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models;
using CityWeather.Data.Models.Dtos;

namespace CityWeather.Data.Services
{
    public class CityDataService: ICityDataService
    {
        private readonly IRepository<CityWeatherContainer, City> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperService _mapperService;

        public CityDataService(IRepository<CityWeatherContainer, City> repository, IUnitOfWork unitOfWork, IMapperService mapperService)
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

        public IEnumerable<CityDto> GetCities()
        {
            return _mapperService.Map<IEnumerable<CityDto>>(_repository.Read());
        }

        public void UpdateCity(int id, CityDto cityDtoModel)
        {
            var cityEntity = _mapperService.Map<City>(cityDtoModel);

            _repository.Read().SingleOrDefault(x => x.Id == id);

            var db = _repository.Context;
            var original = db.Cities.Find(id);

            cityEntity.Id = id;

           if (original != null)
           {
               db.Entry(original).CurrentValues.SetValues(cityEntity);
               db.SaveChanges();
           }
           _unitOfWork.Complete();
        }

        public void DeleteCity(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Complete();
        }
    }
}
