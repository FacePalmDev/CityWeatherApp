using System.Collections.Generic;

namespace CityWeather.Data.Contracts
{
    public interface IRepository<TContext,TEntity>
    {
        void Create(TEntity item);
        IEnumerable<TEntity> Read();
        void Update(int id, TEntity item);
        void Delete(int id);
    }
}