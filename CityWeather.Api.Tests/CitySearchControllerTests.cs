using System.Collections.Generic;
using System.Linq;
using CityWeather.Api.Controllers;
using CityWeather.Api.Models;
using CityWeather.Data.Contracts.Services;
using CityWeather.Domain.Contracts;
using CityWeather.Domain.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CityWeather.Api.Tests
{
    [TestClass]
    public class CitySearchControllerTests
    {
        private CitySearchController _sutCityController;
        private Mock<ICitySearchDomainService> _mockCitySearchDomainService;
        private Mock<IMapperService> _mockMapperService;


        [TestInitialize()]
        public void Startup()
        {
            _mockMapperService = new Mock<IMapperService>();

            _mockMapperService
                .Setup(x =>
                    x.Map<IEnumerable<CitySearchResultApiModel>>(It.IsAny<IEnumerable<CitySearchResultDomainModel>>()))
                .Returns(new List<CitySearchResultApiModel>
                {
                    new CitySearchResultApiModel
                    {
                        Id = 0,
                        CityName = "Lupeni"
                    }
                });


            _mockCitySearchDomainService = new Mock<ICitySearchDomainService>();

            _mockCitySearchDomainService.Setup(x => x.Search("Lupeni"))
                .Returns(new List<CitySearchResultDomainModel>
                {
                    new CitySearchResultDomainModel()
                    {
                        Id = 0,
                        CityName = "Lupeni"
                    }
                });


            _sutCityController =
                new CitySearchController(_mockMapperService.Object, _mockCitySearchDomainService.Object);
        }

        [TestMethod]
        public void Can_Instantiate()
        {
            _sutCityController.Should().NotBeNull();
        }

        [TestMethod]
        public void Can_Search()
        {
            var searchTerm = "Lupeni";
            var results = _sutCityController.Get(searchTerm);

            _mockMapperService.Verify(x => x.Map<IEnumerable<CitySearchResultApiModel>>(It.IsAny<IEnumerable<CitySearchResultDomainModel>>()));
            results.Count().Should().Be(1);
        }

    }
}


