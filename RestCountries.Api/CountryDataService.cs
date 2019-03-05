using CityWeather.Common.Settings;
using RestCountries.Models;
using RestSharp;
using RestSharp.Serialization.Json;

namespace RestCountries.Api
{
    public class CountryDataService : ICountryDataService
    {
        public Country GetCountryData(string countryCode)
        {
            var client = new RestClient(UrlSettings.CountryApiBaseUrl);
            var request = new RestRequest($"alpha/{countryCode}", Method.GET);

            var response = client.Execute(request);

            JsonDeserializer deserializer = new JsonDeserializer();

            return deserializer.Deserialize<Country>(response);
        }
    }
}