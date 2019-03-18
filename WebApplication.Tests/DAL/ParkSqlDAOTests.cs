using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class ParkSqlDAOTests: NPGeekDAOTests
    {
        [TestMethod]
        public void GetParks_Should_Return_AllParks()
        {
            // Arrange
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);

            // Act
            IList<Park> parks = dao.GetParks();

            // Assert
            Assert.AreEqual(1, parks.Count);
        }


        [DataTestMethod]
        [DataRow("FNP", true)]
        [DataRow("CVNP", false)]
        public void GetPark_By_ParkCode_Should_ReturnCorrectNumberOfParks(string parkCode, bool isAPark)
        {
            // Arrange
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);
            bool parkCodeIsThere = false;
            Park park = dao.GetPark(parkCode);

            // Act
            if(park.ParkCode==parkCode)
            {
                parkCodeIsThere= true;
            }

            // Assert
            Assert.AreEqual(isAPark,parkCodeIsThere);

        }



    }
}
