using System;
using System.Collections.Generic;

namespace CityWeather.Api.Models
{
    /// <summary>
    /// Search results model for the api 
    /// </summary>
    public class CitySearchResultApiModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityState { get; set; }

        public CountrySummarySearchResultApiModel CountrySummary { get; set; }
        public CityWeatherReportApiModel WeatherReport { get; set; }

        public uint TouristRating { get; set; }
        public DateTime EstablishedDate { get; set; }
        public int EstimatedPopulation { get; set; }

        public string IsoCountry2LetterCode { get; set; }
        public string IsoCountry3LetterCode { get; set; }

    }
}
