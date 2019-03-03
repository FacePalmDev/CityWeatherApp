using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeather.Data.Contracts;
using CityWeather.Data.Entities;

namespace CityWeather.Data
{
    internal class UnitOfWork: IUnitOfWork
    {
        private readonly CityWeatherContainer _context;

        public UnitOfWork(CityWeatherContainer context)
        {
            _context = context;
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
