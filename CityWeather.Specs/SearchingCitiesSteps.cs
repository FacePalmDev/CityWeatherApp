using System;
using TechTalk.SpecFlow;

namespace CityWeather.Specs
{
    [Binding]
    public class SearchingCitiesSteps
    {
        [Given(@"The city ""(.*)"" exists in the system")]
        public void GivenTheCityExistsInTheSystem(string cityName)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"The search term ""(.*)"" is used")]
        public void WhenTheSearchTermIsUsed(string cityName)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The search results should contain ""(.*)""")]
        public void ThenTheSearchResultsShouldContain(string cityName)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The number of results returned should be (.*)")]
        public void ThenTheNumberOfResultsReturnedShouldBe(int count)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
