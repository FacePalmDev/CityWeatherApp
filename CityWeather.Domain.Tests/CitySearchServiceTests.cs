using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using CityWeather.Common.Mappings;
using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models.Dtos;
using CityWeather.Domain.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestCountries.Api;
using RestCountries.Models;

namespace CityWeather.Domain.Tests
{
    [TestClass]
    public class CitySearchServiceTests
    {
        private ICitySearchDomainService _sutDomainService;
        private MapperService _mockMapperService;
        private Mock<ICityDataService> _mockDataService;
        private Mock<ICountryRestService> _mockCountryRestService;

        [TestInitialize()]
        public void Startup()
        {
            IEnumerable<CityDto> fakeCities = new List<CityDto>()
            {
                new CityDto()
                {
                    Name = "London",
                    EstablishedDate = DateTime.Now,
                    CountryCode = "GB"
            
                },
                new CityDto()
                {
                    Name = "Manchester",
                    EstablishedDate = DateTime.Now,
                    CountryCode = "GB"

                },
                new CityDto()
                {
                    Name = "Tokyo",
                    EstablishedDate = DateTime.Now,
                    CountryCode = "JP"
                },
            };

            _mockMapperService = new MapperService();

            _mockDataService = new Mock<ICityDataService>();
            _mockDataService.Setup(x => x.GetCities()).Returns(fakeCities);

            _mockDataService
                .Setup(x => x.CreateCity(It.IsAny<CityDto>()))
                .Verifiable();

            _mockCountryRestService = new Mock<ICountryRestService>();

            // todo: DEBT => I know that this can be done with a lambda which would make it neater.
            // I'm running a little low on time so I'll stick with this for now. 
            // given more time I'd like to add this to a test helper class.
          
            _mockCountryRestService
            .Setup(x => x.GetCountryData("GB")).Returns(
                    new Country()
                    {
                        Alpha2Code = "GB",
                        Currencies = new EditableList<Currency>
                        {
                            new Currency
                            {
                                Code = "GBP",
                                Name = "Pounds",
                                Symbol = "£"
                            }
                        }
                    });
            _mockCountryRestService
            .Setup(x => x.GetCountryData("JP")).Returns(
                new Country()
                {
                    Alpha2Code = "JP",
                    Currencies = new EditableList<Currency>
                    {
                        new Currency
                        {
                            Code = "YEN",
                            Name = "YEN",
                            Symbol = "¥"
                        }
                    }
                });

            _sutDomainService = new CitySearchDomainService(_mockMapperService, _mockDataService.Object, _mockCountryRestService.Object);
        }

        [TestMethod]
        public void Can_Instantiate()
        {
            _sutDomainService.Should().NotBeNull();
        }

        [TestMethod]
        public void Can_Search_Existing_Cities()
        {
            var results = _sutDomainService.Search("o").ToList();
            results.Should().NotBeNull();
            results.Count().Should().Be(2);
        }

        [TestMethod]
        public void Can_Search_Case_Insensitive()
        {
            var results = _sutDomainService.Search("lon").ToList();
            results.Should().NotBeNull();
            results.Count().Should().Be(1);
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


