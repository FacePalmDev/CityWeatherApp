using CityWeather.Common.Settings;
using RestCountries.Models;
using RestServices.Domain;
using RestSharp;

namespace RestCountries.Domain.Services
{
    /// <summary>
    /// The Country Rest Service Helper.
    /// </summary>
    /// <seealso cref="Country" />
    /// <seealso cref="RestCountries.Api.ICountryRestService" />
    /// <inheritdoc cref="RestCountries.Api.ICountryRestService"/>
    public class CountryRestService : RestService<Country>, ICountryRestService
    {

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