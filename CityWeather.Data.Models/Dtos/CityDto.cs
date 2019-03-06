using System;

namespace CityWeather.Data.Models.Dtos
{
    public class CityDto
    {

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int? Id { get; set; }

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
        public string CountryCode { get; set; }

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
        public int EstimatedPopulation { get; set; }

    }
}
