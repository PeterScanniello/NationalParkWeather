using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Extensions;
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

        public IActionResult Forecast(string id,string pref)
        {
            if(pref == null)
            {
                pref = HttpContext.Session.GetString("TempPref");
                {
                    if (pref == null)
                    {
                        pref = "F";
                    }
                }
            }
            else
            {
                HttpContext.Session.SetString("TempPref", pref);
            }

            ViewData["TempPref"] = pref;
            IList<Forecast> forecasts = forecastDAO.GetForecastsByPark(id);

            return View(forecasts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
