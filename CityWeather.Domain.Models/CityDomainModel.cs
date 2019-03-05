using System;

namespace CityWeather.Domain.Models
{
    public class CityDomainModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country2 letter code.
        /// </summary>
        /// <value>
        /// The country2 letter code.
        /// </value>
        public string Country2LetterCode { get; set; }

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
        /// however... SQL doesn't support uint.
        /// int 2,147,483,647 yeah that will do. 
        /// </remarks>
        public int EstimatedPopulation { get; set; }
    }
}
