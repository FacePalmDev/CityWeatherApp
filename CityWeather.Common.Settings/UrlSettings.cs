using System.Configuration;

namespace CityWeather.Common.Settings
{
    public class UrlSettings
    {
        public static string CountryApiBaseUrl { get; } = ConfigurationManager.AppSettings["CountryApiBaseUrl"];
    }
}