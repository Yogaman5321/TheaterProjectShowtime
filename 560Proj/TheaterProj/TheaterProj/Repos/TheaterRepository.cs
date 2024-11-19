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
    public class TheaterRepository : ITheaterRepository
    {
        //NOTE: You MUST run the GetConnectionString script in order to get the correct connection string.
        //Just copy and paste it here. If you get an error in the string about an escape command, just put an extra \ by it.
        private readonly string _connectionString = "data source=Hunter\\LOCALDB#C0445AB7;initial catalog=master;trusted_connection=true";

        public IList<Theater> _theaterList;

        public TheaterRepository()
        {
            _theaterList = GetAllTheaters();
        }

        public IList<Theater> GetAllTheaters()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Theaters.GetAllTheaters", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateTheaters(reader);
                }
            }
        }

        private IList<Theater> TranslateTheaters(SqlDataReader reader)
        {
            var theaters = new List<Theater>();

            var theaterIDOrdinal = reader.GetOrdinal("TheaterID");
            var locationIDOrdinal = reader.GetOrdinal("LocationID");
            var theaterChainIDOrdinal = reader.GetOrdinal("TheaterChainID");
            var theaterNameOrdinal = reader.GetOrdinal("TheaterName");

            while (reader.Read())
            {
                theaters.Add(new Theater(
                   reader.GetInt32(theaterIDOrdinal),
                   reader.GetInt32(locationIDOrdinal),
                   reader.GetInt32(theaterChainIDOrdinal),
                   reader.GetString(theaterNameOrdinal)));
            }

            return theaters;
        }
    }
}
