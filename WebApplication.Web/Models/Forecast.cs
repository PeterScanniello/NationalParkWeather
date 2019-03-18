using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Forecast
    {
        /// <summary>
        /// Code associated with a park
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string ParkCode { get; set; }

        /// <summary>
        /// Day of the week
        /// </summary>
        [Required]
        public int Day { get; set; }

        /// <summary>
        /// Low temperature of forecast
        /// </summary>
        [Required]
        public int Low { get; set; }

        /// <summary>
        /// High temperature of forecast
        /// </summary>
        [Required]
        public int High { get; set; }

        /// <summary>
        /// Type of weather
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Weather { get; set; }

        /// <summary>
        /// Advice based on weather condition
        /// </summary>
        public IList<string> Advice { get; set; }

        /// <summary>
        /// Temperature unit preference
        /// </summary>
        public string TempPreference { get; set; }
    }
}
