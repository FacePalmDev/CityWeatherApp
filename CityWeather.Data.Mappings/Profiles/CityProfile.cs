using AutoMapper;
using CityWeather.Data.Models;
using CityWeather.Data.Models.Dtos;
using CityWeather.Domain.Models;

namespace CityWeather.Common.Mappings.Profiles
{
    public class CityMappingCreator : Profile
    {
        public CityMappingCreator()
        {
            CreateMap<CityDomainModel, CityDto>().ReverseMap();
            CreateMap<CityDto, City>().ReverseMap();
        }
    }
}
