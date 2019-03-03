using System.Collections.Generic;

namespace CityWeather.Data.Contracts
{
    internal interface IRepository<T>
    {
        void Create(T item);
        IEnumerable<T> Read();
        void Update(int id, T item);
        void Delete(int id);
    }
}