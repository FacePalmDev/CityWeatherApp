using System;
using System.Collections;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Linq;
using FluentAssertions;

namespace CityWeather.Specs
{
    [Binding]
    public class AddingCitiesSteps
    {
        private List<City> _systemCities;

        [Given(@"That no example cities exist in the system")]
        public void GivenThatNoExampleCitiesExistInTheSystem()
        {
            _systemCities = new List<City>();
        }

        /* I've put two attributes here just to make the feature file language cleaner */
        [Given(@"That the city ""(.*)"" does not exist in the system")]
        [Given(@"the city ""(.*)"" does not exist in the system")]
        public void GivenThatTheCityDoesNotExistInTheSystem_(string cityName)
        {
            _systemCities.RemoveAll(x=>x.Name == cityName);
        }
        
        [Given(@"That example cities already exist in the system")]
        public void GivenThatExampleCitiesAlreadyExistInTheSystem()
        {
            _systemCities = new List<City>()
            {
                new City() { Name = "London" },
                new City() { Name = "Oxford" },
                new City() { Name = "Sheffield" }
            };
        }
        
        [When(@"the system is instructed to add the city ""(.*)""")]
        public void WhenTheSystemIsInstructedToAddTheCity(string cityName)
        {
            _systemCities.Add(new City() { Name = cityName });
        }

        [Then(@"the city ""(.*)"" should be present in the system")]
        public void ThenTheCityShouldBePresentInTheSystem(string cityName)
        {
            _systemCities
                .FirstOrDefault(x => x.Name == cityName)
                .Should().NotBeNull();
        }

        [Then(@"the total number of cities should equal (.*)\.")]
        public void ThenTheTotalNumberOfCitiesShouldEqual_(int expectedCityCount)
        {
            _systemCities.Count().Should().Be(expectedCityCount);

        }

        [Then(@"the system should raise an error saying ""(.*)""\.")]
        public void ThenTheSystemShouldRaiseAnErrorSaying_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }

    internal class City
    {
        public string Name { get; set; }
    }
}
