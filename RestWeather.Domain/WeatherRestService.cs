using System;
using CityWeather.Common.Settings;
using RestServices.Domain;
using RestServices.Domain.Contracts;
using RestSharp;
using RestWeather.Models;

namespace RestWeather.Domain
{
    public class WeatherRestService: RestService<WeatherReport>, IWeatherRestService
    {
        public override RestClient Client { get; }

        public WeatherRestService()
        {
            Client = new RestClient(new Uri(UrlSettings.WeatherApiBaseUrl));
        }

        public WeatherReport GetWeatherReport(string cityName)
        {
            var request = new RestRequest($"weather?q={ cityName },uk&appid={ UrlSettings.WeatherAppId }", Method.GET);
            return GetDeserializedObject(request);
        }

    }
}
