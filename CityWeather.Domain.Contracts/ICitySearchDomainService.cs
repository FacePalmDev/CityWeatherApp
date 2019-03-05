using System.Collections.Generic;
using CityWeather.Domain.Models;

namespace CityWeather.Domain.Contracts
{
    public interface ICitySearchDomainService
    {
        IEnumerable<CitySearchResultDomainModel> Search(string searchTerm);
    }
}