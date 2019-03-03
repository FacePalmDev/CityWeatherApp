using System;
using System.Collections.Generic;
using System.Data.Entity;
using CityWeather.Data.Contracts;

namespace CityWeather.Data
{
    internal class Repository<TContext, TEntity> : IRepository<TEntity> 
        where TContext: DbContext 
        where TEntity: class
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(TContext context)
        {
            _dbSet = context.Set<TEntity>();
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
