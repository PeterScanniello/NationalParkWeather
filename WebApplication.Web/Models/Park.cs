using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Park
    {
        /// <summary>
        /// Code associated with a park
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string ParkCode { get; set; }

        /// <summary>
        /// Name of park
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ParkName { get; set; }

        /// <summary>
        /// State park is in
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string State { get; set; }

        /// <summary>
        /// Amount of acres
        /// </summary>
        [Required]
        public int Acreage { get; set; }

        /// <summary>
        /// Park elevation
        /// </summary>
        [Required]
        public int ElevationInFeet { get; set; }

        /// <summary>
        /// Total amount of trail miles
        /// </summary>
        [Required]
        public int MilesOfTrail { get; set; }

        /// <summary>
        /// Amount of campsites
        /// </summary>
        [Required]
        public int NumberOfCampsites { get; set; }

        /// <summary>
        /// Climate type
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Climate { get; set; }

        /// <summary>
        /// Year park was founded
        /// </summary>
        [Required]
        public int YearFounded { get; set; }

        /// <summary>
        /// Count of annual visitors
        /// </summary>
        [Required]
        public int AnnualVisitorCount { get; set; }

        /// <summary>
        /// Quote about the park
        /// </summary>
        [Required]
        public string InspirationalQuote { get; set; }

        /// <summary>
        /// Describes where the quote came from
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string InspirationalQuoteSource { get; set; }

        /// <summary>
        /// Synopsis of a park
        /// </summary>
        [Required]
        public string ParkDescription { get; set; }

        /// <summary>
        /// Amount of dollars required per day
        /// </summary>
        [Required]
        public decimal EntryFee { get; set; }

        /// <summary>
        /// Amount of animal species
        /// </summary>
        [Required]
        public int NumberOfAnimalSpecies { get; set; }

        public IList<Survey> Surveys { get; set; }
    }
}
