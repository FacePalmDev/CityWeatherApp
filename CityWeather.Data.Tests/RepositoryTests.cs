using System.Collections.Generic;
using CityWeather.Data.Models;
using CityWeather.Data.Repositories;
using EntityFrameworkMock;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CityWeather.Data.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private Repository<CityWeatherContext, City> _sutRepo;
        private readonly DbContextMock<CityWeatherContext> _mockContext;
        private readonly DbSetMock<City> _mockCitiesDbSet;

        public RepositoryTests()
        {
            var initialCities = new List<City>();

            _mockContext = new DbContextMock<CityWeatherContext>();
            _mockCitiesDbSet= _mockContext.CreateDbSetMock(x => x.Cities, initialCities);
        }

        [TestInitialize()]
        public void Startup()
        {
            _sutRepo = new Repository<CityWeatherContext, City>(_mockContext.Object);
        }

        [TestMethod]
        public void Can_Instantiate()
        {
            _sutRepo.Should().NotBeNull();
        }

        [TestMethod]
        public void Can_Create()
        {
            var city = new City();
            _sutRepo.Create(city);
            _mockCitiesDbSet.Verify(x=>x.Add(city), Times.Exactly(1));
        }

    }
}
