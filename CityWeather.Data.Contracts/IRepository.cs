using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace CityWeather.Data.Contracts
{
    public interface IRepository<TContext,TEntity>
    {
        TContext Context { get; }
        void Create(TEntity item);
        IEnumerable<TEntity> Read();
        void Update(int id, TEntity entity, params string[] updatedProperties);
        void Delete(int id);
    }
}