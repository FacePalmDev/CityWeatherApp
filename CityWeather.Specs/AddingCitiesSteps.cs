using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Linq;
using CityWeather.Api.Controllers;
using CityWeather.Api.DependencyResolution;
using CityWeather.Api.Models;
using CityWeather.Common.Mappings;
using CityWeather.Data.Contracts;
using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models;
using CityWeather.Data.Models.Dtos;
using CityWeather.Data.Services;
using CityWeather.Domain;
using CityWeather.Specs.TestHelpers;
using FluentAssertions;
using Moq;

// todo: This doesn't really test anything concrete yet but I need each layer coded up.

namespace CityWeather.Specs
{
    [Binding]
    public class AddingCitiesSteps
    {
        private List<City> _exampleCityEntities;
        private Mock<IRepository<CityWeatherContext, City>> _mockCityRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private MapperService _mapperService;
        private CityController _cityApiController;

        [BeforeScenario()]
        public void BeforeScenario()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.Complete()).Verifiable();

            _mockCityRepository = new Mock<IRepository<CityWeatherContext, City>>();
            _mockCityRepository.Setup(x => x.Read()).Returns(_exampleCityEntities);
            _mockCityRepository.Setup(x => x.Create(It.IsAny<City>()))
                .Callback((City city) => _exampleCityEntities.Add(city));

            _mapperService = new MapperService();

            var cityDataService = new CityDataService(
                _mockCityRepository.Object,
                _mockUnitOfWork.Object,
                _mapperService);

            var cityDomainService = new CityDomainService(_mapperService, cityDataService);

            _cityApiController = new CityController(_mapperService, cityDomainService);
        }

        [Given(@"That no example cities exist in the system")]
        public void GivenThatNoExampleCitiesExistInTheSystem()
        {
            _exampleCityEntities = new List<City>();
        }

        [Given(@"That the city ""(.*)"" does not exist in the system")]
        [Given(@"the city ""(.*)"" does not exist in the system")]
        public void GivenThatTheCityDoesNotExistInTheSystem_(string cityName)
        {
            _exampleCityEntities.RemoveAll(x => x.Name == cityName);
        }

        [Given(@"That example cities already exist in the system")]
        public void GivenThatExampleCitiesAlreadyExistInTheSystem()
        {
            _exampleCityEntities = EntityModelTestHelper.GetCities().ToList();
        }

        [When(@"the system is instructed to add the city ""(.*)""")]
        public void WhenTheSystemIsInstructedToAddTheCity(string cityName)
        {
            var exampleCity = ApiModelTestHelper.GetExampleCities().First(x => x.Name == cityName);
            _cityApiController.Post(exampleCity);
        }

        [Then(@"the city ""(.*)"" should be present in the system")]
        public void ThenTheCityShouldBePresentInTheSystem(string cityName)
        {
            _exampleCityEntities
                .FirstOrDefault(x => x.Name == cityName)
                .Should().NotBeNull();
        }

        [Then(@"the total number of cities should equal (.*)\.")]
        public void ThenTheTotalNumberOfCitiesShouldEqual_(int expectedCityCount)
        {
            _exampleCityEntities.Count().Should().Be(expectedCityCount);
        }

    }
}
