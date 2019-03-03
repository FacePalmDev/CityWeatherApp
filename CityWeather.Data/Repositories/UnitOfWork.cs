using System.Threading.Tasks;
using CityWeather.Data.Contracts;
using CityWeather.Data.Models;

namespace CityWeather.Data.Repositories
{
    internal class UnitOfWork: IUnitOfWork
    {
        private readonly CityWeatherContainer _context;

        public UnitOfWork(CityWeatherContainer context)
        {
            _context = context;
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
