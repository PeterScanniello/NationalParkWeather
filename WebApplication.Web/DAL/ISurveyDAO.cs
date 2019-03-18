using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public interface ISurveyDAO
    {
        /// <summary>
        /// Returns surveys for a given park code
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        IList<Survey> GetSurveys(string parkCode);

        /// <summary>
        /// Saves a new survey to the database
        /// </summary>
        /// <param name="survey"></param>
        void SaveNewSurvey(Survey survey);
    }
}
