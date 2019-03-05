using System;
using System.Collections.Generic;
using System.Linq;
using CityWeather.Api.Models;
using CityWeather.Common.Mappings;
using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models.Dtos;
using CityWeather.Domain.Contracts;
using CityWeather.Domain.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CityWeather.Domain.Tests
{
    [TestClass]
    public class CitySearchServiceTests
    {
        private ICitySearchDomainService _sutDomainService;
        private MapperService _mockMapperService;
        private Mock<ICityDataService> _mockDataService;

        [TestInitialize()]
        public void Startup()
        {
            IEnumerable<CityDto> fakeCities = new List<CityDto>()
            {
                new CityDto()
                {
                    Name = "London",
                    EstablishedDate = DateTime.Now
                },
                new CityDto()
                {
                    Name = "Manchester",
                    EstablishedDate = DateTime.Now
                },
                new CityDto()
                {
                    Name = "Londonderry",
                    EstablishedDate = DateTime.Now
                },
            };

            _mockMapperService = new MapperService();

            _mockDataService = new Mock<ICityDataService>();
            _mockDataService.Setup(x => x.GetCities()).Returns(fakeCities);

            _mockDataService
                .Setup(x => x.CreateCity(It.IsAny<CityDto>()))
                .Verifiable();
            ;
            _sutDomainService = new CitySearchDomainService(_mockMapperService, _mockDataService.Object);
        }

        [TestMethod]
        public void Can_Instantiate()
        {
            _sutDomainService.Should().NotBeNull();
        }

        [TestMethod]
        public void Can_Search_Existing_Cities()
        {
            var results = _sutDomainService.Search("London").ToList();
            results.Should().NotBeNull();
            results.Count().Should().Be(2);
        }

        [TestMethod]
        public void Can_Search_Case_Insensitive()
        {
            var results = _sutDomainService.Search("london").ToList();
            results.Should().NotBeNull();
            results.Count().Should().Be(2);
        }

        [TestMethod]
        public void Can_Returns_Empty_When_No_Items_Found()
        {
            var results =
                _sutDomainService.Search("someplacethatwillhopefullyneverexist")
                .ToList();

            results.Should().NotBeNull();
            results.Count().Should().Be(0);

        }
    }
}


