using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CityWeather.Data.Contracts;

namespace CityWeather.Data.Repositories
{
    public class Repository<TContext, TEntity> : IRepository<TContext, TEntity> 
        where TContext: DbContext 
        where TEntity: class
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(TContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        
        public void Create(TEntity item)
        {
            _dbSet.Add(item);

        }

        public IEnumerable<TEntity> Read()
        {
            return _dbSet;
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
