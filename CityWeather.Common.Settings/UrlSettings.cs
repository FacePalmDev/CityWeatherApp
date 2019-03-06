using System;
using System.Configuration;

namespace CityWeather.Common.Settings
{
    public class UrlSettings
    {
        public static string CountryApiBaseUrl { get; } = ConfigurationManager.AppSettings["CountryApiBaseUrl"];
        public static string WeatherApiBaseUrl { get; } = ConfigurationManager.AppSettings["WeatherApiBaseUrl"];
        public static object WeatherAppId { get; set; } = ConfigurationManager.AppSettings["WeatherAppId"];
    }
}