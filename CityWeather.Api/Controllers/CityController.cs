using System.Web.Http;
using CityWeather.Api.Models;
using CityWeather.Data.Contracts.Services;
using CityWeather.Domain.Contracts;
using CityWeather.Domain.Models;

namespace CityWeather.Api.Controllers
{
    public class CityController : ApiController
    {
        private readonly IMapperService _mapperService;
        private readonly ICityDomainService _cityDomainService;

        public CityController(IMapperService mapperService, ICityDomainService cityDomainService)
        {
            _mapperService = mapperService;
            _cityDomainService = cityDomainService;
        }

        public void Post([FromBody] CityApiModel city)
        {
            _cityDomainService.CreateCity(_mapperService.Map<CityDomainModel>(city));
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]CityUpdateApiModel city)
        {
            _cityDomainService.UpdateCity(id, _mapperService.Map<CityDomainModel>(city));
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
            _cityDomainService.DeleteCity(id);
        }
    }
}
