using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using CityWeather.Data.Contracts;

namespace CityWeather.Data.Repositories
{
    public class Repository<TContext, TEntity> : IRepository<TContext, TEntity> 
        where TContext: DbContext 
        where TEntity: class
    {
        public TContext Context { get; }
        private readonly DbSet<TEntity> _dbSet;

        public Repository(TContext context)
        {
            Context = context;
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
     
        public void Delete(int id)
        {
            var found = _dbSet.Find(id);
            if (found != null)
            {
                _dbSet.Remove(found);
            }
        }
    }
}
