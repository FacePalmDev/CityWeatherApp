using AutoMapper;
using CityWeather.Common.Mappings.Profiles;
using CityWeather.Data.Contracts.Services;

namespace CityWeather.Common.Mappings
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CityMappingProfile>();
                cfg.AddProfile<CitySearchMappingProfile>();
            });

            _mapper = new Mapper(config);
        }

        public TDest Map<TDest>(object source)
        {
            return _mapper.Map<TDest>(source);
        }
    }
}