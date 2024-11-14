using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheaterData.Models;

namespace TheaterProj.Repos
{
    public class ShowTimeRepository : IShowTimeRepository
    {
        //NOTE: You MUST run the GetConnectionString script in order to get the correct connection string.
        //Just copy and paste it here. If you get an error in the string about an escape command, just put an extra \ by it.
        private readonly string _connectionString = "data source=Hunter\\LOCALDB#C0445AB7;initial catalog=master;trusted_connection=true";

        public IList<Showtime> _showTimeList;

        public ShowTimeRepository()
        {
            _showTimeList = GetAllShowTimes();
        }


        public void AddShowTime(int screenID, DateTime date, int movieID)
        {
            throw new NotImplementedException();
        }

        public IList<Showtime> GetAllShowTimes()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Theaters.GetAllShowTimes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateShowTimes(reader);
                }
            }
        }

        private IList<Showtime> TranslateShowTimes(SqlDataReader reader)
        {
            var showTimes = new List<Showtime>();

            var screenIDOrdinal = reader.GetOrdinal("ScreenID");
            var movieIDOrdinal = reader.GetOrdinal("MovieID");
            var dateTimeOrdinal = reader.GetOrdinal("DateTime");

            while (reader.Read())
            {
                showTimes.Add(new Showtime(
                   reader.GetInt32(screenIDOrdinal),
                   reader.GetInt32(movieIDOrdinal),
                   reader.GetDateTime(dateTimeOrdinal)));          
            }

            return showTimes;
        }
    }
}
