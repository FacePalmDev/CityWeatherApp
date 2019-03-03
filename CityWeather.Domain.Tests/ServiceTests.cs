using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CityWeather.Domain.Tests
{
    [TestClass]
    public class ServiceTests
    {
        private CityService _sutService;

        [TestInitialize()]
        public void Startup()
        {
            _sutService = new CityService();
        }

        [TestMethod]
        public void Can_Instantiate()
        {
            _sutService.Should().NotBeNull();
        }

    }
}

    
