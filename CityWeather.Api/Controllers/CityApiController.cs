using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using CityWeather.Api.Models;
using CityWeather.Data.Contracts.Services;
using CityWeather.Domain.Contracts;
using CityWeather.Domain.Models;

namespace CityWeather.Api.Controllers
{
    public class CityApiController : ApiController
    {
        private readonly IMapperService _mapperService;
        private readonly ICityDomainService _cityDomainService;

        public CityApiController(IMapperService mapperService, ICityDomainService cityDomainService)
        {
            _mapperService = mapperService;
            _cityDomainService = cityDomainService;
        }

        public string Get()
        {
            return "hello";
        }

        public void Post([FromBody] CityApiModel city)
        {
            _cityDomainService.CreateCity(_mapperService.Map<CityDomainModel>(city));
        }
    }

}
