using System;

namespace CityWeather.Domain.Models
{
    public class CitySearchResultDomainModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityState { get; set; }

        public CountrySummaryDomainModel CountrySummary { get; set; }
        public CityWeatherReportDomainModel WeatherReport { get; set; }

        public uint TouristRating { get; set; }
        public DateTime EstablishedDate { get; set; }
        public int EstimatedPopulation { get; set; }

        public string Country2LetterCode { get; set; }
        public string Country3LetterCode { get; set; }
    }
}
