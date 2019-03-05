using RestCountries.Models;

namespace RestCountries.Domain.Services
{
    public interface ICountryRestService
    {
        Country GetCountryData(string countryCode);
    }
}