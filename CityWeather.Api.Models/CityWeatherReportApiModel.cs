using System.Collections.Generic;

namespace CityWeather.Api.Models
{
    /// <summary>
    /// An Api Model for the Weather data.
    /// </summary>
    public class CityWeatherReportApiModel
    {
        /// <summary>
        /// Gets or sets the weather report description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public List<string> WeatherReportDescriptions { get; set; }
    }
}
