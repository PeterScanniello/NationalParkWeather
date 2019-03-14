using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Survey
    {
        [Required]
        public int SurveyId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string ParkCode { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(30)]
        public string State { get; set; }

        [Required]
        [MaxLength(100)]
        public string ActivityLevel { get; set; }
    }
}
