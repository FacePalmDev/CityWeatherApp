using System.Collections.Generic;
using AutoMapper;
using CityWeather.Api.Models;
using CityWeather.Domain.Models;
using RestCountries.Models;

namespace CityWeather.Common.Mappings.Profiles
{
    public class CitySearchMappingProfile : Profile
    {
        public CitySearchMappingProfile()
        {
            CreateMap<Country, CountrySummaryDomainModel>()
                .ForMember(dest => dest.CurrencyCodes, opt => opt.ResolveUsing(GetCountryCurrencyCode));
                
            CreateMap<(CityDomainModel, CountrySummaryDomainModel), CitySearchResultDomainModel>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Item1.Name))
                .ForMember(dest => dest.CountrySummary, opt => opt.MapFrom(src => src.Item2));

            CreateMap<CitySearchResultDomainModel, CitySearchResultApiModel>();
            CreateMap<CountrySummaryDomainModel, CountrySummarySearchResultApiModel>();
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
