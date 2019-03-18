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

        /// <summary>
        /// Returns all of the forecasts
        /// </summary>
        /// <returns></returns>
        public IList<Forecast> GetAllForecasts()
        {
            IList<Forecast> forecasts = new List<Forecast>();
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather", conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row and create a forecast
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

        /// <summary>
        /// Retrieve forecasts by Park Code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<Forecast> GetForecastsByPark(string id)
        {
            IList<Forecast> theOnesWeWant = new List<Forecast>();
            IList<Forecast> forecasts = GetAllForecasts();
            foreach(Forecast forecast in forecasts)
            {
                if(forecast.ParkCode==id)
                {
                    theOnesWeWant.Add(forecast);
                }
            }
            return theOnesWeWant;
        }

        /// <summary>
        /// Dictionary containing weather conditions with advice as values 
        /// </summary>
        public Dictionary<string, string> Advice = new Dictionary<string, string>()
            {
                { "snow", "Pack snowshoes" },
                {"rain", "Pack rain gear and wear waterproof shoes" },
                {"thunderstorms", "Seek shelter and avoid hiking on exposed ridges" },
                {"sunny", "Pack sunblock" },
            };


        /// <summary>
        /// Determine weather advice based on conditions
        /// </summary>
        /// <param name="newForecast"></param>
        /// <returns></returns>
        public List<string> GetAdvice(Forecast newForecast)
        {
            List<string> advice = new List<string>();
            foreach (KeyValuePair<string, string> kvp in Advice)
            {
                if (kvp.Key == newForecast.Weather)
                {
                    advice.Add(kvp.Value);
                }
            }

            if(newForecast.High>75)
            {
                advice.Add("Bring an extra gallon of water");
            }
            if((newForecast.High-newForecast.Low)>20)
            {
                advice.Add("Wear breathable layers");
            }
            if(newForecast.Low<20)
            {
                advice.Add("Be aware, exposure to frigid temperatures can have a negative impact on your health and happiness, up to and including death.");
            }

            return advice;
        }

        private Forecast ConvertReaderToForecast(SqlDataReader reader)
        {
            // Create a Forecast
            Forecast forecast = new Forecast();

            forecast.ParkCode = Convert.ToString(reader["parkCode"]);
            forecast.Day = Convert.ToInt32(reader["fiveDayForecastValue"]);
            forecast.Low = Convert.ToInt32(reader["low"]);
            forecast.High = Convert.ToInt32(reader["high"]);
            forecast.Weather = Convert.ToString(reader["forecast"]);
            forecast.Advice = GetAdvice(forecast);

            return forecast;
        }
    }
}

