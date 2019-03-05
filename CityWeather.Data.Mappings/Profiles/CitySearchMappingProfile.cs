using AutoMapper;
using CityWeather.Api.Models;
using CityWeather.Data.Models.Dtos;
using CityWeather.Domain.Models;

namespace CityWeather.Common.Mappings.Profiles
{
    public class CitySearchMappingProfile : Profile
    {
        public CitySearchMappingProfile()
        {
            CreateMap<CityDto, CitySearchResultDomainModel>()
                .ForMember(dest => dest.CityName,
                    opt => opt.MapFrom(src => src.Name));
           CreateMap<CitySearchResultDomainModel, CitySearchResultApiModel>();
        }
    }
}
