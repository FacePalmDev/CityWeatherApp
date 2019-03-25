using System;
using System.Collections.Generic;
using System.Web.Http;
using CityWeather.Api.Models;
using CityWeather.Data.Contracts.Services;
using CityWeather.Domain.Contracts;

namespace CityWeather.Api.Controllers
{
    public class CitySearchController : ApiController
    {
        private readonly IMapperService _mapperService;
        private readonly ICitySearchDomainService _citySearchDomainService;

        public CitySearchController(IMapperService mapperService, ICitySearchDomainService citySearchDomainService)
        {
            _mapperService = mapperService;
            _citySearchDomainService = citySearchDomainService;
        }

        // GET: api/CitySearch/5
        public IHttpActionResult Get(string cityName)
        {
            throw new Exception("Bang");

            var citySearchResult = _citySearchDomainService.Search(cityName);
            IEnumerable<CitySearchResultApiModel> result;
            try
            {
                result = _mapperService.Map<IEnumerable<CitySearchResultApiModel>>(citySearchResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }
    }
}