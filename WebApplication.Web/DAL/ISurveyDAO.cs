using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public interface ISurveyDAO
    {
        IList<Survey> GetSurveys(string parkCode);
        void SaveNewSurvey(Survey survey);
    }
}
