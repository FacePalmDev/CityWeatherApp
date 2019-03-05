using RestCountries.Models;

namespace RestCountries.Api
{
    public interface ICountryRestService
    {
        Country GetCountryData(string countryCode);
    }
}