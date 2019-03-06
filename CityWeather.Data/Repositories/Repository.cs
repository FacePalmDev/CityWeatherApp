using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

        public void Update(int id, TEntity entity, params string[] updatedProperties)
        {
            if (updatedProperties.Any())
            {
                var originalEntity = _dbSet.Find(id);
                //update explicitly mentioned properties
                foreach (var property in updatedProperties)
                {
                    var newValue = TryGetProperty(entity, property);
                    TrySetProperty(originalEntity, property, newValue);
                }
                
                _dbSet.AddOrUpdate(originalEntity);
            }
        }

        // todo: Technical Debt. Using reflection as a last resort here. 
        // I'm just a little low on time. It works but deserves a rethink.

        private static void TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);
        }

        private static object TryGetProperty(object obj, string property)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            return prop != null ? prop.GetValue(obj) : null;
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
