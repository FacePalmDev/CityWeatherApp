using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Castle.Components.DictionaryAdapter;
using CityWeather.Api.Controllers;
using CityWeather.Api.Models;
using CityWeather.Data.Models;
using CityWeather.Specs.TestHelpers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace CityWeather.Specs
{
    [Binding]
    public class SearchingCitiesSteps
    {
        private List<CityApiModel> _cityEntities;
        public CitySearchController _citySearchController;
        private IEnumerable<CitySearchResultApiModel>_lastSearchResult;

        [BeforeScenario()]
        private void BeforeScenario()
        {
            _cityEntities = new List<CityApiModel>();
           // _citySearchController = new CitySearchController();
        }

        [Given(@"The city ""(.*)"" exists in the system")]
        public void GivenTheCityExistsInTheSystem(string cityName)
        {
             var newCityApiModel = ApiModelTestHelper.CreateCityModel(cityName);
            _cityEntities.Add(newCityApiModel);
        }
        
        [When(@"The search term ""(.*)"" is used")]
        public void WhenTheSearchTermIsUsed(string searchTerm)
        {
            _lastSearchResult = _citySearchController.Get(searchTerm);
        }
        
        [Then(@"The search results should contain ""(.*)""")]
        public void ThenTheSearchResultsShouldContain(string cityName)
        {
            _lastSearchResult.Any(x=>x.CityName == cityName).Should().BeTrue();
        }
        
        [Then(@"The number of results returned should be (.*)")]
        public void ThenTheNumberOfResultsReturnedShouldBe(int count)
        {
            _lastSearchResult.Count().Should().Be(count);

        }
    }
}
