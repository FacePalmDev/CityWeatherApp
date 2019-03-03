using AutoMapper;
using CityWeather.Data.Models;
using CityWeather.Data.Models.Dtos;

namespace CityWeather.Data.Mappings.Profiles
{
    internal class CityMappingCreator: Profile
    {
        public CityMappingCreator()
        {
            CreateMap<City, CityDto>();
        }
    }
}
