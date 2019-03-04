using AutoMapper;
using CityWeather.Api.Models;
using CityWeather.Data.Models;
using CityWeather.Data.Models.Dtos;
using CityWeather.Domain.Models;

namespace CityWeather.Common.Mappings.Profiles
{
    public class CityMappingProfile : Profile
    {
        public CityMappingProfile()
        {
            CreateMap<CityApiModel, CityDomainModel > ().ReverseMap();
            CreateMap<CityDomainModel, CityDto>().ReverseMap();
            CreateMap<CityDto, City>().ReverseMap();
        }
    }
}
