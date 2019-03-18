using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class SurveySqlDAOTests:NPGeekDAOTests
    {

        [DataTestMethod]
        [DataRow("FNP", 1)]
        [DataRow("CVNP", 0)]
        public void GetSurveys_By_ParkCode_Should_ReturnCorrectNumberOfSurveys(string parkCode, int expectedCount)
        {
            // Arrange
            SurveySqlDAO dao = new SurveySqlDAO(ConnectionString);

            // Act
            IList<Survey> surveys = dao.GetSurveys(parkCode);

            // Assert
            Assert.AreEqual(expectedCount, surveys.Count);
        }

        [TestMethod]
        public void AddSurvey_Should_IncreaseCountBy1()
        {
            Survey survey = new Survey();
            survey.ParkCode = "FNP";
            survey.State = "New Mexico";
            survey.EmailAddress = "joe@fakeemail.com";
            survey.ActivityLevel = "active";

            // Arrange
            SurveySqlDAO dao = new SurveySqlDAO(ConnectionString);
            int startingRowCount = GetRowCount("survey_result");

            // Act
            dao.SaveNewSurvey(survey);

            int endingRowCount = GetRowCount("survey_result");

            //Assert
            Assert.AreNotEqual(startingRowCount, endingRowCount);

        }


    }
}
