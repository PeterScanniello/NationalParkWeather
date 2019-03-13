using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class ForecastSqlDAO : IForecastDAO
    {
        private string connectionString;
        public ForecastSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Forecast> GetAllForecastsByPark(string parkCode)
        {
            IList<Forecast> forecasts = new List<Forecast>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE weather.parkCode = @parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Forecast forecast = ConvertReaderToForecast(reader);
                        forecasts.Add(forecast);

                    }
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
            return forecasts;
        }

        private Forecast ConvertReaderToForecast(SqlDataReader reader)
        {
            Forecast forecast = new Forecast();

            forecast.ParkCode = Convert.ToString(reader["parkCode"]);
            forecast.Day = Convert.ToInt32(reader["fiveDayForecastValue"]);
            forecast.Low = Convert.ToInt32(reader["low"]);
            forecast.High = Convert.ToInt32(reader["high"]);
            forecast.Weather = Convert.ToString(reader["forecast"]);

            return forecast;
        }
    }
    }
}
