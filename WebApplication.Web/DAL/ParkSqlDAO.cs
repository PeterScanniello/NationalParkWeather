using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private string connectionString;
        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Retrieve a park through matching a park id and its corresponding park code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Park GetPark(string id)
        {
            Park newPark = new Park();
            IList<Park> parks = GetParks();
            foreach (Park park in parks)
            {
                if(park.ParkCode == id)
                {
                    newPark = park;
                }
            }
            return newPark;   
        }

        /// <summary>
        /// Returns all of the parks
        /// </summary>
        /// <returns></returns>
        public IList<Park> GetParks()
        {
            IList<Park> parks = new List<Park>();
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park", conn);

                    // Execute the commad
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row and create a park
                    while (reader.Read())
                    {
                        Park park = ConvertReaderToPark(reader);
                        parks.Add(park);
                    }
                }
             }
            catch (SqlException ex)
            {

                throw;
            }
            return parks;
        }

        private Park ConvertReaderToPark(SqlDataReader reader)
        {
            // Create a Park
            Park park = new Park();
           
            park.ParkCode = Convert.ToString(reader["ParkCode"]);
            park.ParkName = Convert.ToString(reader["ParkName"]);
            park.State = Convert.ToString(reader["State"]);
            park.Acreage = Convert.ToInt32(reader["Acreage"]);
            park.ElevationInFeet = Convert.ToInt32(reader["ElevationInFeet"]);
            park.MilesOfTrail = Convert.ToInt32(reader["MilesOfTrail"]);
            park.NumberOfCampsites = Convert.ToInt32(reader["NumberOfCampsites"]);
            park.Climate = Convert.ToString(reader["Climate"]);
            park.YearFounded = Convert.ToInt32(reader["YearFounded"]);
            park.AnnualVisitorCount = Convert.ToInt32(reader["AnnualVisitorCount"]);
            park.InspirationalQuote = Convert.ToString(reader["InspirationalQuote"]);
            park.ParkDescription = Convert.ToString(reader["ParkDescription"]);
            park.EntryFee = Convert.ToDecimal(reader["EntryFee"]);
            park.NumberOfAnimalSpecies = Convert.ToInt32(reader["NumberOfAnimalSpecies"]);

            return park;
        }
    }
}
