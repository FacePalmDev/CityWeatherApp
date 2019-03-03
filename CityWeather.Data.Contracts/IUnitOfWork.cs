using System.Threading.Tasks;

namespace CityWeather.Data.Contracts
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}
