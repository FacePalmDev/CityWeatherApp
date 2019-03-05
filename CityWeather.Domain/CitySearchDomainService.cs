using System.Collections.Generic;
using System.Linq;
using CityWeather.Data.Contracts.Services;
using CityWeather.Domain.Contracts;
using CityWeather.Domain.Models;
using RestCountries.Models;
using RestServices.Domain.Contracts;

namespace CityWeather.Domain
{
    public class CitySearchDomainService : ICitySearchDomainService
    {
        private readonly IMapperService _mapperService;
        private readonly ICityDataService _cityDataService;
        private readonly IWeatherRestService _weatherService;
        private readonly ICountryRestService _countryRestService;

        public CitySearchDomainService(IMapperService mapperService, 
            ICityDataService cityDataService, IWeatherRestService weatherService, 
            ICountryRestService countryRestService)
        {
            _mapperService = mapperService;
            _cityDataService = cityDataService;
            _weatherService = weatherService;
            _countryRestService = countryRestService;
        }

        public IEnumerable<CitySearchResultDomainModel> Search(string searchTerm)
        {
            var matchingCityDtos = _cityDataService.GetCities()
                .Where(city => city.Name.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant()));

            var cityDomainModels = 
                _mapperService.Map<IEnumerable<CityDomainModel>>(matchingCityDtos)
                .ToList();

            var distinctCountryCodes = cityDomainModels.Select(city => city.Country2LetterCode).Distinct();
            var countrySummaries = GetAllCountrySummaries(distinctCountryCodes).ToList();
            var citiesWeatherAndCountries = new List<(CityDomainModel, CityWeatherReportDomainModel, CountrySummaryDomainModel)>();

            foreach (var searchResult in cityDomainModels)
            {
                var country = countrySummaries.First(x => x.Alpha2Code == searchResult.Country2LetterCode);
                var fullWeatherReport = _weatherService.GetWeatherReport(searchResult.Name);
                var weatherSummary = _mapperService.Map<CityWeatherReportDomainModel>(fullWeatherReport);

                citiesWeatherAndCountries.Add((searchResult, weatherSummary, country));
            }

           var result = _mapperService.Map<IEnumerable<CitySearchResultDomainModel>>(citiesWeatherAndCountries);

           return result;
        }

        private IEnumerable<CountrySummaryDomainModel> GetAllCountrySummaries(IEnumerable<string> distinctCountryCodes)
        {
            foreach (var countryCode in distinctCountryCodes)
            {
                var countryData = _countryRestService.GetCountryData(countryCode);
                yield return GetCountrySummary(countryData);
            }
        }

        private CountrySummaryDomainModel GetCountrySummary(Country countryData)
        {
            return _mapperService.Map<CountrySummaryDomainModel>(countryData);
        }


    }
}