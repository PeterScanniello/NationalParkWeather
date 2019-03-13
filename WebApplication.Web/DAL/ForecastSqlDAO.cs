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

        public IList<Forecast> GetAllForecasts()
        {
            IList<Forecast> forecasts = new List<Forecast>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather", conn);
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

        public Dictionary<string, string> Advice = new Dictionary<string, string>()
            {
                { "snow", "Pack snowshoes" },
                {"rain", "Pack rain gear and wear waterproof shoes" },
                {"thunderstorms", "Seek shelter and avoid hiking on exposed ridges" },
                {"sunny", "Pack sunblock" },
            };


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

