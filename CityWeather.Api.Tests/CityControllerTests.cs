
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CityWeather.Api;
using CityWeather.Api.Controllers;
using CityWeather.Api.Models;
using CityWeather.Data.Contracts.Services;
using CityWeather.Domain.Contracts;
using CityWeather.Domain.Models;

namespace CityWeather.Domain.Tests
{
    [TestClass]
    public class CityControllerTests
    {
        private CityController _sutCityController;
        private Mock<ICityDomainService> _mockCityDomainService;
        private Mock<IMapperService> _mockMapperService;


        [TestInitialize()]
        public void Startup()
        {

            _mockMapperService = new Mock<IMapperService>();

            _mockMapperService
                .Setup(x => x.Map<CityDomainModel>(It.IsAny<CityApiModel>()))
                .Verifiable();

            _mockCityDomainService = new Mock<ICityDomainService>();

            _mockCityDomainService.Setup(
                    x => x.CreateCity(It.IsAny<CityDomainModel>()))
                .Verifiable();

            _sutCityController = 
                new CityController(_mockMapperService.Object, _mockCityDomainService.Object);
        }

        [TestMethod]
        public void Can_Instantiate()
        {
            _sutCityController.Should().NotBeNull();
        }

        [TestMethod]
        public void Can_Create()
        {
            var fakeCity = new CityApiModel()
            {
                Name = "Test"
            };

            _sutCityController.Post(fakeCity);

            _mockMapperService.Verify(x => x.Map<CityDomainModel>(fakeCity), Times.Once());
            _mockCityDomainService.Verify(x=>x.CreateCity(It.IsAny<CityDomainModel>()));
        }

    }
}


