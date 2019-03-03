using System.Threading.Tasks;

namespace CityWeather.Data.Contracts
{
    internal interface IUnitOfWork
    {
        Task Complete();
    }
}
