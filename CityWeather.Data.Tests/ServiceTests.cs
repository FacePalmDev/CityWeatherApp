using CityWeather.Data.Contracts;
using CityWeather.Data.Contracts.Services;
using CityWeather.Common.Mappings;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CityWeather.Data.Models.Dtos;
using CityWeather.Data.Services;
using City = CityWeather.Data.Models.City;

namespace CityWeather.Data.Tests
{
    [TestClass]
    public class ServiceTests
    {
        private CityDataService _sutService;
        private readonly Mock<IRepository<City>> _mockRepo;
        private readonly Mock<IUnitOfWork> _mockUow;
        private Mock<IMapperService> _mockMapperService;

        public ServiceTests()
        {
            _mockRepo = new Mock<IRepository<City>>();

            _mockRepo
                .Setup(x => x.Create(It.IsAny<City>()))
                .Verifiable();

            _mockUow = new Mock<IUnitOfWork>();

            _mockUow 
                .Setup(x => x.Complete())
                .Verifiable();

            _mockMapperService = new Mock<IMapperService>();

            _mockMapperService
                .Setup(x=>x.Map<City>(It.IsAny<CityDto>()))
                .Verifiable();
                
        }

        [TestInitialize()]
        public void Startup()
        {
            _sutService = new CityDataService(_mockRepo.Object, _mockUow.Object, _mockMapperService.Object);
        }

        [TestMethod]
        public void Can_Instantiate()
        {
            _sutService.Should().NotBeNull();
        }

        [TestMethod]
        public void Can_Create()
        {
            var cityDto = new CityDto() { Name = "example" };

            _sutService.CreateCity(cityDto);

            _mockRepo.Verify(x => x.Create(It.IsAny<City>()), Times.Once);
            _mockUow.Verify(x => x.Complete(), Times.Once);
            _mockMapperService.Verify(x=>x.Map<City>(cityDto), Times.Once());
        }

    }
}
