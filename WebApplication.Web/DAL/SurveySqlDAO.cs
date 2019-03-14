using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class SurveySqlDAO : ISurveyDAO
    {
        private string connectionString;
        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Survey> GetSurveys()
        {
            IList<Survey> surveys = new List<Survey>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM survey_result", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Survey survey = ConvertReaderToSurvey(reader);
                        surveys.Add(survey);
                    }
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
        }

        private Survey ConvertReaderToSurvey(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void SaveNewSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result ( Values ( )

                }
            }
            catch (SqlException ex)
            {

                throw;
            }
        }
    }
}
