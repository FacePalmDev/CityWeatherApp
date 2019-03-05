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

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<CityApiModel, CityDomainModel>().ReverseMap();
            CreateMap<CityDomainModel, CityDto>()
                .ForMember(dest => dest.CountryCode,
                    opt => opt.MapFrom(src => src.Country2LetterCode));

            CreateMap<CityDto, CityDomainModel>()
                .ForMember(dest => dest.Country2LetterCode,
                    opt => opt.MapFrom(src => src.CountryCode));

            CreateMap<CityDto, CitySearchResultDomainModel>()
                .ForMember(dest => dest.CityName,
                    opt => opt.MapFrom(src => src.Name));
        }
    }
}
