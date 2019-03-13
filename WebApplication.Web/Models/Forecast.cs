using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class Forecast
    {
        public string ParkCode {get; set;}

        public int Day { get; set; }

        public int Low { get; set; }
        
        public int High { get; set; }

        public string Weather { get; set; }

        public IList<string> Advice { get; set; }

    }
}
