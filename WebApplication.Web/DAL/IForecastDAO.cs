using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IForecastDAO
    {
        /// <summary>
        /// Returns forecasts for a given park code
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        IList<Forecast> GetForecastsByPark(string parkCode);

        /// <summary>
        /// Returns all  forecasts
        /// </summary>
        /// <returns></returns>
        IList<Forecast> GetAllForecasts();
    }
}
        
