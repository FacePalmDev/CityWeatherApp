namespace CityWeather.Data.Contracts.Services
{
    public interface IMapperService
    {
        TDest Map<TDest>(object source);
    }
}