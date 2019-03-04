using CityWeather.Common.Mappings;
using CityWeather.Data.Contracts;
using CityWeather.Data.Contracts.Services;
using CityWeather.Data.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CityWeather.Data.Models.Dtos;
using CityWeather.Data.Services;


namespace CityWeather.Data.Tests
{
    [TestClass]
    public class ServiceTests
    {
        private ICityDataService _sutDataService;
        private readonly Mock<IRepository<CityWeatherContext,City>> _mockRepo;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<IMapperFactory> _mockMapperFactory;
        private readonly Mock<IMapperService> _mockMapperService;

        public ServiceTests()
        {
            _mockRepo = new Mock<IRepository<CityWeatherContext, City>>();

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

            _mockMapperFactory = new Mock<IMapperFactory>();
            _mockMapperFactory.Setup(x => x.GetMapper()).Returns(_mockMapperService.Object);

        }

        [TestInitialize()]
        public void Startup()
        {
            _sutDataService = new CityDataService(_mockRepo.Object, _mockUow.Object, _mockMapperFactory.Object);
        }

        [TestMethod]
        public void Can_Instantiate()
        {
            _sutDataService.Should().NotBeNull();
        }

        [TestMethod]
        public void Can_Create()
        {
            var cityDto = new CityDto() { Name = "example" };

            _sutDataService.CreateCity(cityDto);

            _mockRepo.Verify(x => x.Create(It.IsAny<City>()), Times.Once);
            _mockUow.Verify(x => x.Complete(), Times.Once);
            _mockMapperService.Verify(x=>x.Map<City>(cityDto), Times.Once());
        }

    }
}
