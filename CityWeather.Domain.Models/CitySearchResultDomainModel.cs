﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeather.Domain.Models
{
    public class CitySearchResultDomainModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityState { get; set; }

        //todo make a model for these.
        public CountrySummaryDomainModel CountrySummary { get; set; }
        public string WeatherSummary { get; set; }

        public uint TouristRating { get; set; }
        public DateTime EstablishedDate { get; set; }
        public int EstimatedPopulation { get; set; }

        public string Country2LetterCode { get; set; }
        public string Country3LetterCode { get; set; }
    }
}
