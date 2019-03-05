using System.Collections.Generic;
using System.Web.Http;
using CityWeather.Api.Models;
using CityWeather.Data.Contracts.Services;
using CityWeather.Domain.Contracts;

namespace CityWeather.Api.Controllers
{
    public class CitySearchController : ApiController
    {
        private IMapperService _mapperService;
        private readonly ICitySearchDomainService _citySearchDomainService;

        public CitySearchController(IMapperService mapperService, ICitySearchDomainService citySearchDomainService)
        {
            _mapperService = mapperService;
            _citySearchDomainService = citySearchDomainService;
        }
        // GET: api/CitySearch/5
        public IEnumerable<CitySearchResultApiModel> Get(string cityName)
        {

            return _mapperService.Map<IEnumerable<CitySearchResultApiModel>>(_citySearchDomainService.Search(cityName));
        }


   
    }
}
