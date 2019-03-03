using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeather.Data.Contracts;

namespace CityWeather.Data
{
    public class Repository<T> : IRepository<T>
    {
        public void Create(T item)
        {
            throw new NotImplementedException();
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
