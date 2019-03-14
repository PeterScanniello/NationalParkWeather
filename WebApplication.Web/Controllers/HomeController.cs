using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDAO;
        private IForecastDAO forecastDAO;
        public HomeController(IParkDAO parkDAO, IForecastDAO forecastDAO)
        {
            this.parkDAO = parkDAO;
            this.forecastDAO = forecastDAO;
        }

        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetParks();
            return View(parks);
        }

        public IActionResult Details(string id)
        {            
            Park park = parkDAO.GetPark(id);
            return View(park);
        }

        public IActionResult Forecast(string id)
        {
            IList<Forecast> forecasts = forecastDAO.GetForecastsByPark(id);

            return View(forecasts);
        }

        private Temperature ChangeTemp()
        {
            Temperature temp = null;

            if (HttpContext.Session.Get<Temperature>("TempPreference") != null)
            {
                temp = HttpContext.Session.Get<Temperature>("TempPreference");
            }
            else
            {
                temp = new Temperature();
                ChangeTempPreference(temp);
            }
            return temp;
        }
        

        private void ChangeTempPreference(Temperature temp)
        {
            HttpContext.Session.Set("TempPreference", temp);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
