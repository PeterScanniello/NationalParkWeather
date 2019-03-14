using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Park
    {
        // public int ParkId { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string ParkCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string ParkName { get; set; }

        [Required]
        [MaxLength(30)]
        public string State { get; set; }

        [Required]
        public int Acreage { get; set; }

        [Required]
        public int ElevationInFeet { get; set; }

        [Required]
        public int MilesOfTrail { get; set; }

        [Required]
        public int NumberOfCampsites { get; set; }

        [Required]
        [MaxLength(100)]
        public string Climate { get; set; }

        [Required]
        public int YearFounded { get; set; }

        [Required]
        public int AnnualVisitorCount { get; set; }

        [Required]
        public string InspirationalQuote { get; set; }

        [Required]
        [MaxLength(200)]
        public string InspirationalQuoteSource { get; set; }

        [Required]
        public string ParkDescription { get; set; }

        [Required]
        public decimal EntryFee { get; set; }

        [Required]
        public int NumberOfAnimalSpecies { get; set; }

        public IList<Survey> Surveys { get; set; }
    }
}
