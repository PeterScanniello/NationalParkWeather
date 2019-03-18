using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.DAL;

namespace WebApplication.Web.Models
{
    public class ParkDetailsViewModel
    {
        /// <summary>
        /// Park object
        /// </summary>
        public Park Park {get;set;}

        public IList<Forecast> Forecasts { get; set; }
    }
}
