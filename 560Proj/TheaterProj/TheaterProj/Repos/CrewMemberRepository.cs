using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheaterData.Models;

namespace TheaterProj.Repos
{   

    public class CrewMemberRepository : ICrewMemberRepository
    {
        //NOTE: You MUST run the GetConnectionString script in order to get the correct connection string.
        //Just copy and paste it here. If you get an error in the string about an escape command, just put an extra \ by it.
        private readonly string _connectionString = "data source=Hunter\\LOCALDB#C0445AB7;initial catalog=master;trusted_connection=true";

        public IList<CrewMember> _crewList;

        public CrewMemberRepository()
        {
            _crewList = GetAllCrewMembers();
        }



        public IList<CrewMember> GetAllCrewMembers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Movies.GetAllCrewMembers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateCrewMembers(reader);
                }
            }
        }

        private IList<CrewMember> TranslateCrewMembers(SqlDataReader reader)
        {
            var crewMembers = new List<CrewMember>();

            var crewMemberIDOrdinal = reader.GetOrdinal("CrewMemberID");
            var movieIDOrdinal = reader.GetOrdinal("MovieID");
            var personTypeIDOrdinal = reader.GetOrdinal("PersonTypeID");
            var firstNameOrdinal = reader.GetOrdinal("FirstName");
            var lastNameOrdinal = reader.GetOrdinal("LastName");

            while (reader.Read())
            {
                crewMembers.Add(new CrewMember(
                   reader.GetInt32(crewMemberIDOrdinal),
                   reader.GetInt32(movieIDOrdinal),
                   (PersonType)personTypeIDOrdinal,
                   reader.GetString(firstNameOrdinal),
                   reader.GetString(lastNameOrdinal)));

            }

            return crewMembers;
        }
    }

    
}
