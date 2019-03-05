using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeather.Api.Models
{
    public class CitySearchResultApiModel
    {
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string CityState { get; set; }

        //todo make a model for these.
        public CountrySummarySearchResultApiModel CountrySummary { get; set; }
        public string WeatherSummary { get; set; }

        public uint TouristRating { get; set; }
        public DateTime EstablishedDate { get; set; }
        public int EstimatedPopulation { get; set; }

        public string IsoCountry2LetterCode { get; set; }
        public string IsoCountry3LetterCode { get; set; }

    }
}
