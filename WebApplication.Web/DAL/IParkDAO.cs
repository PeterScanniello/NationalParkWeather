using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    interface IParkDAO
    {
        Park GetPark(int id);

        IList<Park> GetParks();
    }
}
