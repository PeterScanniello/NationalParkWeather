using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IParkDAO
    {
        /// <summary>
        /// Returns a park with the associated park code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Park GetPark(string code);

        /// <summary>
        /// Returns all parks
        /// </summary>
        /// <returns></returns>
        IList<Park> GetParks();
    }
}
