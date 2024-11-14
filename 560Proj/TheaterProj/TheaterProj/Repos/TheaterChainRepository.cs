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
    public class TheaterChainRepository : ITheaterChainRepository
    {
        //NOTE: You MUST run the GetConnectionString script in order to get the correct connection string.
        //Just copy and paste it here. If you get an error in the string about an escape command, just put an extra \ by it.
        private readonly string _connectionString = "data source=Hunter\\LOCALDB#C0445AB7;initial catalog=master;trusted_connection=true";

        public IList<TheaterChain> _theaterChainList;

        public TheaterChainRepository()
        {
            _theaterChainList = GetAllTheaterChains();
        }


        public IList<TheaterChain> GetAllTheaterChains()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Theaters.GetAllTheaterChains", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateTheaterChains(reader);
                }
            }
        }

        private IList<TheaterChain> TranslateTheaterChains(SqlDataReader reader)
        {
            var theaterChains = new List<TheaterChain>();

            var theaterChainIDOrdinal = reader.GetOrdinal("TheaterChainID");
            var theaterChainNameOrdinal = reader.GetOrdinal("TheaterChainName");

            while (reader.Read())
            {
                theaterChains.Add(new TheaterChain(
                   reader.GetInt32(theaterChainIDOrdinal),
                   reader.GetString(theaterChainNameOrdinal)));
            }

            return theaterChains;
        }
    }
}
