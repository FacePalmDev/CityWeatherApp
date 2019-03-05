using System.Collections.Generic;
using AutoMapper;
using CityWeather.Api.Models;
using CityWeather.Domain.Models;
using RestCountries.Models;
using RestWeather.Models;

namespace CityWeather.Common.Mappings.Profiles
{
    public class CitySearchMappingProfile : Profile
    {
        public CitySearchMappingProfile()
        {
            CreateMap<CityWeatherReportDomainModel, CityWeatherReportApiModel>();

            CreateMap<Country, CountrySummaryDomainModel>()
                .ForMember(dest => dest.CurrencyCodes, opt => opt.ResolveUsing(GetCountryCurrencyCode));

            CreateMap<(CityDomainModel, CityWeatherReportDomainModel, CountrySummaryDomainModel), 
                    CitySearchResultDomainModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Item1.Id))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Item1.Name))
                .ForMember(dest => dest.CityState, opt => opt.MapFrom(src => src.Item1.Name))
                .ForMember(dest => dest.EstablishedDate, opt => opt.MapFrom(src => src.Item1.EstablishedDate))
                .ForMember(dest => dest.EstimatedPopulation, opt => opt.MapFrom(src => src.Item1.EstimatedPopulation))
                .ForMember(dest => dest.TouristRating, opt => opt.MapFrom(src => src.Item1.TouristRating))
                .ForMember(dest => dest.WeatherReport, opt => opt.MapFrom(src => src.Item2))
                .ForMember(dest => dest.CountrySummary, opt => opt.MapFrom(src => src.Item3));

            CreateMap<CitySearchResultDomainModel, CitySearchResultApiModel>();
            CreateMap<CountrySummaryDomainModel, CountrySummarySearchResultApiModel>();
            CreateMap<WeatherReport, CityWeatherReportDomainModel>()
                .ForMember(dest => dest.WeatherReportDescriptions, opt => opt.ResolveUsing(GetWeatherDescriptions));
          
        }

        // todo: consider making a generic method that these all call. 
        // given more time perhaps I could make these generic. On the other hand this 
        // can make things a bit unreadable and over optimized. It will do for now. 
        // meeting the requirement is my priority for now.
         
        private static List<string> GetWeatherDescriptions(WeatherReport src)
        {
            var result = new List<string>();

            foreach (var weather in src.weather)
            {
                result.Add(weather.description);
            }

            return result;
        }

        private static List<string> GetCountryCurrencyCode(Country src)
        {
            var result = new List<string>();

            foreach (var currency in src.Currencies)
            {
               result.Add(currency.Code);
            }

            return result;
        }
    }
}
