using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDAO;

        public HomeController(IParkDAO parkDAO)
        {
            this.parkDAO = parkDAO;
        }

        private IForecastDAO forecastDAO;

        public HomeController(IForecastDAO forecastDAO)
        {
            this.forecastDAO = forecastDAO;
        }

        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetParks();
            return View(parks);
        }

        public IActionResult Details(string parkCode)
        {
            
            Park park = parkDAO.GetPark(parkCode);
            return View(park);
        }

        public IActionResult Forecast(string parkCode)
        {
            IList<Forecast> forecasts = forecastDAO.GetAllForecastsByPark(parkCode);            
            return View(forecasts);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
