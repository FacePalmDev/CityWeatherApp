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
using TechTalk.SpecFlow;

namespace CityWeather.Specs
{
    [Binding]
    public class SearchingCitiesSteps
    {

        public CitySearchController _citySearchController;
        private IEnumerable<CitySearchResultApiModel> _lastSearchResult;
        private IMapperService _mapperService;
        private CitySearchDomainService _citySearchDomainService;
        private List<City> _exampleCityEntities;
        private Mock<IRepository<CityWeatherContainer, City>> _mockCityRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private CityDataService _cityDataService;

        [BeforeScenario()]
        private void BeforeScenario()
        {
            _exampleCityEntities = new List<City>();

            _mapperService = new MapperService();

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            _mockCityRepository = new Mock<IRepository<CityWeatherContainer, City>>();
            _mockCityRepository.Setup(x => x.Read()).Returns(_exampleCityEntities);



            _cityDataService = new CityDataService(_mockCityRepository.Object, _mockUnitOfWork.Object, _mapperService);
            _citySearchDomainService =
                new CitySearchDomainService(_mapperService, _cityDataService);

            _citySearchController = new CitySearchController(_mapperService, _citySearchDomainService);
        }

        [Given(@"The city ""(.*)"" exists in the system")]
        public void GivenTheCityExistsInTheSystem(string cityName)
        {
            var newCityApiModel = new City()
            {
                CountryCode = "GB",
                EstablishedDate = new DateTime(),
                EstimatedPopulation = 8787892,
                Name = cityName,
                Id = 0,
                State = "SomeState",
                TouristRating = 5
            };

            _exampleCityEntities.Add(newCityApiModel);
        }

        [When(@"The search term ""(.*)"" is used")]
        public void WhenTheSearchTermIsUsed(string searchTerm)
        {
            _lastSearchResult = _citySearchController.Get(searchTerm);
        }

        [Then(@"The search results should contain ""(.*)""")]
        public void ThenTheSearchResultsShouldContain(string cityName)
        {
            _lastSearchResult.Any(x => x.CityName == cityName).Should().BeTrue();
        }

        [Then(@"The number of results returned should be (.*)")]
        public void ThenTheNumberOfResultsReturnedShouldBe(int count)
        {
            _lastSearchResult.Count().Should().Be(count);

        }

        [Then(@"The seach results should contain country data for ""(.*)""")]
        public void ThenTheSeachResultsShouldContainCountryDataFor()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
