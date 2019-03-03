using AutoMapper;
using CityWeather.Data.Contracts.Factories;
using CityWeather.Data.Contracts.Services;

namespace CityWeather.Data.Mappings
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDest Map<TDest>(object source)
        {
            return _mapper.Map<TDest>(source);
        }
    }
}