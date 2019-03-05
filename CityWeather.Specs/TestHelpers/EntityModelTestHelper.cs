using System.Collections.Generic;
using CityWeather.Data.Models;

namespace CityWeather.Specs.TestHelpers
{
    public class EntityModelTestHelper
    {
        public static IEnumerable<City> GetCities()
        {
            return new List<City>()
            {
                new City() { Name = "London" },
                new City() { Name = "Oxford" },
                new City() { Name = "Sheffield" }
            };
        }
    }
}