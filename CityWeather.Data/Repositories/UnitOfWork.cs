using System.Threading.Tasks;
using CityWeather.Data.Contracts;
using CityWeather.Data.Models;

namespace CityWeather.Data.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly CityWeatherContext _context;

        public UnitOfWork(CityWeatherContext context)
        {
            _context = context;
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
