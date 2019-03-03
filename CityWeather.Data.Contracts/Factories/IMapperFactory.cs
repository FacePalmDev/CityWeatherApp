
using CityWeather.Data.Contracts.Services;

namespace CityWeather.Data.Contracts.Factories
{
    public interface IMapperFactory
    {
        IMapperService GetMapper();
    }
}