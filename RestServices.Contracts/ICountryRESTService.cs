using RestCountries.Models;

namespace RestServices.Domain.Contracts
{
    public interface ICountryRestService
    {
        Country GetCountryData(string countryCode);
    }
}