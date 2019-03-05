using RestCountries.Models;

namespace RestCountries.Api
{
    public interface ICountryDataService
    {
        Country GetCountryData(string countryCode);
    }
}