using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class ForecastSqlDAOTests:NPGeekDAOTests
    {
        [TestMethod]
        public void GetAllForecasts_Should_Return_AllForecasts()
        {
            // Arrange
            ForecastSqlDAO dao = new ForecastSqlDAO(ConnectionString);

            // Act
            IList<Forecast> forecasts = dao.GetAllForecasts();

            // Assert
            Assert.AreEqual(1, forecasts.Count);
        }

        [DataTestMethod]
        [DataRow("FNP", 1)]
        [DataRow("CVNP", 0)]
        public void GetForecast_By_ParkCode_Should_ReturnCorrectNumberOfForecasts(string parkCode, int expectedCount)
        {
            // Arrange
            ForecastSqlDAO dao = new ForecastSqlDAO(ConnectionString);

            // Act
            IList<Forecast> forecasts = dao.GetForecastsByPark(parkCode);

            // Assert
            Assert.AreEqual(expectedCount, forecasts.Count);

        }



    }
}
