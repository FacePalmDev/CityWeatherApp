using System.Reflection;
using AutoMapper;
using CityWeather.Data.Contracts.Factories;
using CityWeather.Data.Contracts.Services;

namespace CityWeather.Common.Mappings
{
    public class MapperFactory: IMapperFactory
    {
        private readonly MapperConfiguration _config;

        public MapperFactory()
        {
            _config = new MapperConfiguration(cfg => {
                cfg.AddProfiles(Assembly.GetExecutingAssembly());
            });
        }
        
        public IMapperService GetMapper()
        {
            return new MapperService(_config.CreateMapper());
        } 
    }
}
