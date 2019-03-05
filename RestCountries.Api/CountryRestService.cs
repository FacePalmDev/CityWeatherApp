using CityWeather.Common.Settings;
using RestCountries.Models;
using RestServices;
using RestSharp;
using RestSharp.Serialization.Json;

namespace RestCountries.Api
{
    /// <summary>
    /// The Country Rest Service Helper.
    /// </summary>
    /// <seealso cref="RestServices.RestService{RestCountries.Models.Country}" />
    /// <seealso cref="RestCountries.Api.ICountryRestService" />
    public class CountryRestService : RestService<Country>, ICountryRestService
    {
        /// <summary>
        /// Gets the rest client.
        /// </summary>
        public override RestClient Client { get; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryRestService"/> class.
        /// </summary>
        public CountryRestService()
        {
            Client = new RestClient(UrlSettings.CountryApiBaseUrl);
        }

        /// <summary>
        /// Gets the country data.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns></returns>
        public Country GetCountryData(string countryCode)
        {
            var request = new RestRequest($"alpha/{countryCode}", Method.GET);

            return GetDeserializedObject(request);
        }

    }
}