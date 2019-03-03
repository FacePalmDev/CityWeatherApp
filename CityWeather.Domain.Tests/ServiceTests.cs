﻿using CityWeather.Api.Models;
using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models.Dtos;
using CityWeather.Domain.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CityWeather.Domain.Tests
{
    [TestClass]
    public class ServiceTests
    {
        private CityDomainService _sutDomainService;
        private Mock<IMapperService> _mockMapperService;
        private Mock<ICityService> _mockDataService;

        [TestInitialize()]
        public void Startup()
        {
            _mockMapperService = new Mock<IMapperService>();

            _mockMapperService
                .Setup(x => x.Map<CityDto>(It.IsAny<CityApiModel>()))
                .Verifiable();

            _mockDataService = new Mock<ICityService>();

            _mockDataService
                .Setup(x => x.CreateCity(It.IsAny<CityDto>()))
                .Verifiable();
            ;
            _sutDomainService = new CityDomainService(_mockMapperService.Object, _mockDataService.Object);
        }

        [TestMethod]
        public void Can_Instantiate()
        {
            _sutDomainService.Should().NotBeNull();
        }

        [TestMethod]
        public void Can_Create()
        {
            var city = new CityDomainModel() { Name = "London" };
            _sutDomainService.CreateCity(city);

            _mockMapperService.Verify(x => x.Map<CityDto>(city), Times.Once());
            _mockDataService.Verify(x=>x.CreateCity(It.IsAny<CityDto>()));
        }

    }
}

