using System.Collections.Generic;
using System.Data.Entity;

namespace CityWeather.Data.Contracts
{
    public interface IRepository<TContext,TEntity>
    {
        TContext Context { get; }
        void Create(TEntity item);
        IEnumerable<TEntity> Read();
        void Delete(int id);
    }
}