using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using CityWeather.Data.Contracts;
using CityWeather.Data.Models;

namespace CityWeather.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CityWeatherContainer _context;

        public UnitOfWork(CityWeatherContainer context)
        {
            _context = context;
        }

        public async Task Complete()
        {
            if (_context.ChangeTracker.HasChanges())
            {
                var validationErrors = _context.GetValidationErrors().ToList();

                if (validationErrors.Any())
                {
                    throw new DbEntityValidationException("Entity validation failed for database save", validationErrors);
                }
                
                // I did have some issues with this but suspect it wasn't a coding issue. 
                await _context.SaveChangesAsync();
            }
        }
    }
}
