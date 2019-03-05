using System.Collections.Generic;
using CityWeather.Api.Models;

namespace CityWeather.Specs.TestHelpers
{
    internal static class ApiModelTestHelper
    {
        internal static IEnumerable<CityApiModel> GetExampleCities()
        {
            return new List<CityApiModel>() {
                new CityApiModel() { Name = "London" },
                new CityApiModel() { Name = "Oxford" },
                new CityApiModel() { Name = "Sheffield" }
            };
        }

    }
}
