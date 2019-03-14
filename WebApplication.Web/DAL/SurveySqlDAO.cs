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

        public IList<Survey> GetSurveys(string parkCode)
        {
            IList<Survey> surveys = new List<Survey>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM survey_result where @parkcode=parkCode order by parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
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
            return surveys;
        }
        

        private Survey ConvertReaderToSurvey(SqlDataReader reader)
        {
            Survey survey = new Survey();
            survey.ParkCode = Convert.ToString(reader["ParkCode"]);
            survey.EmailAddress = Convert.ToString(reader["EmailAddress"]);
            survey.State = Convert.ToString(reader["State"]);
            survey.ActivityLevel = Convert.ToString(reader["ActivityLevel"]);

            return survey;
        }

        public void SaveNewSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result Values (@ParkCode, @EmailAddress, @State, @ActivityLevel);", conn);
                    cmd.Parameters.AddWithValue("@ParkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@EmailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@State", survey.State);
                    cmd.Parameters.AddWithValue("@ActivityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
        }
    }
}
