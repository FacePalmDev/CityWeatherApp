using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using CityWeather.Api.Models;
using CityWeather.Data.Contracts.Services;
using CityWeather.Domain.Contracts;
using CityWeather.Domain.Models;
using StructureMap.Diagnostics;

namespace CityWeather.Api.Controllers
{
    public class CityController : BaseController
    {
        private readonly IMapperService _mapperService;
        private readonly ICityDomainService _cityDomainService;

        public CityController(IMapperService mapperService, ICityDomainService cityDomainService)
        {
            _mapperService = mapperService;
            _cityDomainService = cityDomainService;
        }

        public IHttpActionResult Post([FromBody] CityApiModel city)
        {
            try
            {
                _cityDomainService.CreateCity(_mapperService.Map<CityDomainModel>(city));
            }
            catch (ValidationException ex)
            {
                return ValidationError(ex);
            }

            return Ok();
        }

        // PUT: api/Default/5
        public IHttpActionResult Put(int id, [FromBody]CityUpdateApiModel city)
        {
            try
            {
                _cityDomainService.UpdateCity(id, _mapperService.Map<CityDomainModel>(city));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        // DELETE: api/Default/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _cityDomainService.DeleteCity(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }
    }
}
