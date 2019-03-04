using System.CodeDom;
using System.Data.Common;
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
                
                // I was attempting to do this asynchronously but ran into some issues where 
                // save changes async wasn't completing. This may have something to do with server locks but
                // I don't have time to investigate right now. So I'll keep this simple. 

                await _context.SaveChangesAsync();
            }
        }
    }
}
