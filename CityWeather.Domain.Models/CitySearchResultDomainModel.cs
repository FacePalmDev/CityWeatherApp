using System;

namespace CityWeather.Domain.Models
{
    public class CitySearchResultDomainModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string CityState { get; set; }

        public CountrySummaryDomainModel CountrySummary { get; set; }
        public CityWeatherReportDomainModel WeatherReport { get; set; }

        public uint TouristRating { get; set; }
        public DateTime EstablishedDate { get; set; }
        public int EstimatedPopulation { get; set; }

    }
}
