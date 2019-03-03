
using CityWeather.Data.Contracts.Services;

namespace CityWeather.Common.Mappings
{
    public interface IMapperFactory
    {
        IMapperService GetMapper();
    }
}