using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Forecast
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string ParkCode {get; set;}

        [Required]
        public int Day { get; set; }

        [Required]
        public int Low { get; set; }

        [Required]
        public int High { get; set; }

        [Required]
        [MaxLength(100)]
        public string Weather { get; set; }
        
        public IList<string> Advice { get; set; }
        

    }
}
