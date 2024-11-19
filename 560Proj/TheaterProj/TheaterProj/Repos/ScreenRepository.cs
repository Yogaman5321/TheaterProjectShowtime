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
    public class ScreenRepository : IScreenRepository
    {
        //NOTE: You MUST run the GetConnectionString script in order to get the correct connection string.
        //Just copy and paste it here. If you get an error in the string about an escape command, just put an extra \ by it.
        private readonly string _connectionString = "data source=Hunter\\LOCALDB#C0445AB7;initial catalog=master;trusted_connection=true";

        public IList<Screen> _screenList;

        public ScreenRepository()
        {
            _screenList = GetAllScreens();
        }


        public IList<Screen> GetAllScreens()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Movies.GetAllScreens", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateScreens(reader);
                }
            }
        }

        private IList<Screen> TranslateScreens(SqlDataReader reader)
        {
            var screens = new List<Screen>();

            var screenIDOrdinal = reader.GetOrdinal("ScreenID");
            var screenTypeOrdinal = reader.GetOrdinal("ScreenType");
            var theaterIDOrdinal = reader.GetOrdinal("TheaterID");
            var screenNumberOrdinal = reader.GetOrdinal("ScreenNumber");

            while (reader.Read())
            {
                screens.Add(new Screen(
                   reader.GetInt32(screenIDOrdinal),
                   (ScreenType)screenTypeOrdinal,
                   reader.GetInt32(theaterIDOrdinal),
                   reader.GetInt32(screenNumberOrdinal)));
            }

            return screens;
        }
    }
}
