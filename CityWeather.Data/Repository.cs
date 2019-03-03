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
    internal class Repository<TContext, TEntity> : IRepository<TEntity> 
        where TContext: DbContext 
        where TEntity: class
    {
        private readonly TContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        
        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public IEnumerable<TEntity> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
