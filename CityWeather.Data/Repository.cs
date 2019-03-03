using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeather.Data.Contracts;
using CityWeather.Data.Entities;

namespace CityWeather.Data
{
    public class Repository<C, T> : IRepository<T> 
        where C: DbContext 
        where T: class
    {
        private readonly C _context;
        private DbSet<T> _dbSet;

        public Repository(C context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        public void Create(T item)
        {
            _dbSet.Add(item);
        }

        public IEnumerable<T> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
