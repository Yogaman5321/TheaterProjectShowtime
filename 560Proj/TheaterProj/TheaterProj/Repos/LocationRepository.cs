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
    public class LocationRepository : ILocationRepository
    {
        //NOTE: You MUST run the GetConnectionString script in order to get the correct connection string. (This one is mine, you need your own.)
        //Just copy and paste it here. If you get an error in the string about an escape command, just put an extra \ by it.
        private readonly string _connectionString = "data source=Hunter\\LOCALDB#C0445AB7;initial catalog=master;trusted_connection=true";

        public IList<Location> _locationList;

        public LocationRepository()
        {
            _locationList = GetAllLocations();
        }

        public IList<Location> GetAllLocations()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Theaters.GetAllLocations", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateLocations(reader);
                }
            }
        }

        private IList<Location> TranslateLocations(SqlDataReader reader)
        {
            var locations = new List<Location>();

            var locationIDOrdinal = reader.GetOrdinal("LocationID");
            var stateOrdinal = reader.GetOrdinal("State");
            var addressOrdinal = reader.GetOrdinal("Address");
            var cityOrdinal = reader.GetOrdinal("City");

            while (reader.Read())
            {
                locations.Add(new Location(
                   reader.GetInt32(locationIDOrdinal),
                   reader.GetString(stateOrdinal),
                   reader.GetString(addressOrdinal),
                   reader.GetString(cityOrdinal)));
            }

            return locations;
        }

    }
}
