﻿using System;
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
        // Pass DAO in with the Constructor
        private IParkDAO parkDAO;
        private IForecastDAO forecastDAO;
        public HomeController(IParkDAO parkDAO, IForecastDAO forecastDAO)
        {
            this.parkDAO = parkDAO;
            this.forecastDAO = forecastDAO;
        }

        /// <summary>
        /// Returns all of the parks
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetParks();
            return View(parks);
        }

        /// <summary>
        /// Defaults temperature to fahrenheit. Stores user's temperature preference between fahrenheit and celcius in session
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pref"></param>
        /// <returns></returns>
        public IActionResult Details(string id, string pref)
        {
            if (pref == null)
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

            Park park = parkDAO.GetPark(id);
            ParkDetailsViewModel model = new ParkDetailsViewModel();
            IList<Forecast> results = forecastDAO.GetForecastsByPark(park.ParkCode);
            model.Park = park;
            model.Forecasts = results;
            return View(model);
        }
    }
}
