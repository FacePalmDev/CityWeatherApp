using System.Collections.Generic;
using System.Data;
using System.Linq;
using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models.Dtos;
using CityWeather.Domain.Contracts;
using CityWeather.Domain.Models;
using RestCountries.Api;
using RestCountries.Models;

namespace CityWeather.Domain
{
    public class CitySearchDomainService : ICitySearchDomainService
    {
        private readonly IMapperService _mapperService;
        private readonly ICityDataService _cityDataService;

        public CitySearchDomainService(IMapperService mapperService, ICityDataService cityDataService)
        {
            _mapperService = mapperService;
            _cityDataService = cityDataService;
        }

        public IEnumerable<CitySearchResultDomainModel> Search(string searchTerm)
        {
            var matchingCities = _cityDataService.GetCities()
                .Where(city => city.Name.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant())).ToList();

            var results = _mapperService.Map< IEnumerable<CitySearchResultDomainModel>>(matchingCities);

            return results;

            // I've started coding this a little too early. I'm commenting it out for now but will add it later.

            // var distinctCountryCodes = matchingCities.Select(city => city.Country2LetterCode).Distinct();
            //var countrySummaries = GetAllCountrySummaries(distinctCountryCodes).ToList();

            //var citiesAndCountries = new List<(CityDto, CountrySummaryDomainModel)>();

            //foreach (var city in matchingCities)
            //{
            //    var country = countrySummaries.First(x => x.Alpha2Code == city.Country2LetterCode);
            //    citiesAndCountries.Add((city, country));
            //}

            // return _mapperService.Map<IEnumerable<CitySearchResultDomainModel>>(citiesAndCountries);
        }

        //private IEnumerable<CountrySummaryDomainModel> GetAllCountrySummaries(IEnumerable<string> distinctCountryCodes)
        //{
        //    foreach (var countryCode in distinctCountryCodes)
        //    {
        //        var countryData = _countryDataService.GetCountryData(countryCode);
        //        yield return GetCountrySummary(countryData);
        //    }
        //}

        //private CountrySummaryDomainModel GetCountrySummary(Country countryData)
        //{
        //    return _mapperService.Map<CountrySummaryDomainModel>(countryData);
        //}

    
    }
}