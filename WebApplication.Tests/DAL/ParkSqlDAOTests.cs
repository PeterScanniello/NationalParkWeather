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
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);

            IList<Park> parks = dao.GetParks();

            Assert.AreEqual(1, parks.Count);
        }


        [DataTestMethod]
        [DataRow("FNP", true)]
        [DataRow("CVNP", false)]
        public void GetPark_By_ParkCode_Should_ReturnCorrectNumberOfParks(string parkCode, bool isAPark)
        {
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);
            bool parkCodeIsThere = false;
            Park park = dao.GetPark(parkCode);

            if(park.ParkCode==parkCode)
            {
                parkCodeIsThere= true;
            }

            Assert.AreEqual(isAPark,parkCodeIsThere);

        }



    }
}
