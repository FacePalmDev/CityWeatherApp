using System;

namespace CityWeather.Api.Models
{

    public class CityUpdateApiModel
    {
        /// <summary>
        /// Converts to tourist rating.
        /// </summary>
        /// <value>
        /// The tourist rating.
        /// </value>
        public short TouristRating { get; set; }

        /// <summary>
        /// Gets or sets the established date.
        /// </summary>
        /// <value>
        /// The established date.
        /// </value>
        public DateTime EstablishedDate { get; set; }

        /// <summary>
        /// Gets or sets the estimated population.
        /// </summary>
        /// <value>
        /// The estimated population.
        /// </value>
        /// <remarks>
        /// Tokyo is currently the most populated city in the world with 9.3 Million people (2015).
        /// uint max value is 4,294,967,295 more than enough. 
        /// </remarks>
        public int EstimatedPopulation { get; set; }
    }
}