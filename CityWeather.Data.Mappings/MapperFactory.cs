using System.Reflection;
using AutoMapper;
using CityWeather.Common.Mappings.Profiles;
using CityWeather.Data.Contracts.Services;

namespace CityWeather.Common.Mappings
{
    public class MapperFactory: IMapperFactory
    {
        private readonly MapperConfiguration _config;

        public MapperFactory()
        {
            _config = new MapperConfiguration(cfg => {
                cfg.AddProfile<CityMappingCreator>();
            });
        }
        
        public IMapperService GetMapper()
        {
            return new MapperService(_config.CreateMapper());
        } 
    }
}
