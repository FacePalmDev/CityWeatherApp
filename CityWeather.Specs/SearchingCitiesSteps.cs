using System;
using System.Collections.Generic;
using System.Linq;
using CityWeather.Api.Controllers;
using CityWeather.Api.Models;
using CityWeather.Common.Mappings;
using CityWeather.Data.Contracts;
using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models;
using CityWeather.Data.Services;
using CityWeather.Domain;
using FluentAssertions;
using Moq;
using RestCountries.Domain;
using RestServices.Domain.Contracts;
using RestWeather.Domain;
using TechTalk.SpecFlow;

namespace CityWeather.Specs
{
    [Binding]
    public class SearchingCitiesSteps
    {

        private CitySearchController _citySearchController;
        private IEnumerable<CitySearchResultApiModel> _lastSearchResults;
        private IMapperService _mapperService;
        private CitySearchDomainService _citySearchDomainService;
        private List<City> _exampleCityEntities;
        private Mock<IRepository<CityWeatherContainer, City>> _mockCityRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private CityDataService _cityDataService;
        private CountryRestService _countryService;
        private WeatherRestService _weatherService;

        [BeforeScenario()]
        private void BeforeScenario()
        {
            _exampleCityEntities = new List<City>();

            _mapperService = new MapperService();

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            _mockCityRepository = new Mock<IRepository<CityWeatherContainer, City>>();
            _mockCityRepository.Setup(x => x.Read()).Returns(_exampleCityEntities);

            /* todo: check if this would be okay for the specs.
             * thought about mocking this, but I don't think a quick REST call is a problem here;
             * besides specs can be longer running tests that also test integration unlike unit tests. 
             * if the 3rd party API changed and broke our system it would be nice to know about it.
             * assuming the tests will be run on a machine with an internet connection. :/
             * in reality I'd check this with the client.
             */

            _countryService = new CountryRestService();
            _weatherService = new WeatherRestService();

            _cityDataService = new CityDataService(_mockCityRepository.Object, _mockUnitOfWork.Object, _mapperService);

            _citySearchDomainService =
                new CitySearchDomainService(_mapperService, _cityDataService, _weatherService, _countryService);

            _citySearchController = new CitySearchController(_mapperService, _citySearchDomainService);
        }

        [Given(@"The city ""(.*)"" exists in the system with country code ""(.*)""")]
        public void GivenTheCityExistsInTheSystem(string cityName, string countryCode)
        {
            var city = new City()
            {
                CountryCode = countryCode,
                EstablishedDate = new DateTime(),
                EstimatedPopulation = 8787892,
                Name = cityName,
                Id = 0,
                State = "SomeState",
                TouristRating = 5
            };

            _exampleCityEntities.Add(city);
        }

        [When(@"The search term ""(.*)"" is used")]
        public void WhenTheSearchTermIsUsed(string searchTerm)
        {
            _lastSearchResults = _citySearchController.Get(searchTerm);
        }

        [Then(@"The search results should contain ""(.*)""")]
        public void ThenTheSearchResultsShouldContain(string cityName)
        {
            _lastSearchResults.Any(x => x.CityName == cityName).Should().BeTrue();
        }

        [Then(@"The number of results returned should be (.*)")]
        public void ThenTheNumberOfResultsReturnedShouldBe(int count)
        {
            _lastSearchResults.Count().Should().Be(count);
        }

        [Then(@"The search results should contain country data for ""(.*)""")]
        public void ThenTheSearchResultsShouldContainCountryDataFor(string countryCode)
        {
            _lastSearchResults.Any(x => x.CountrySummary.Alpha2Code == countryCode)
                .Should().BeTrue();
        }

        [Then(@"The search results should contain a weather description")]
        public void ThenTheSearchResultsShouldContainAWeatherDescription()
        {
            _lastSearchResults.All(x => x.WeatherReport.WeatherReportDescriptions.Any())
                .Should().BeTrue();
        }



    }
}
