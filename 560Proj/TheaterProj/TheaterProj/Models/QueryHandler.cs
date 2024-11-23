using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TheaterProj.Models;
using System.Net;

namespace TheaterProj
{
    public static class QueryHandler
    {

        private static readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=ProjDatabase;Integrated Security=SSPI;";    
        

        public static IEnumerable<Movie> GetAllMovies()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("EXEC Movies.RetrieveAllMovies", connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();

                    using (var reader = command.ExecuteReader()) return TranslateAllMovies(reader);
                }
            }
        }

        private static IEnumerable<Movie> TranslateAllMovies(SqlDataReader reader)
        {
            List<Movie> results = new List<Movie>();

            string movieName = "";
            int releaseYear = 0;
            int runtime = 0;
            decimal averageUserScore = 0;


            var movieNameOrdinal = reader.GetOrdinal("MovieName");
            var releaseYearOrdinal = reader.GetOrdinal("ReleaseYear");
            var runtimeOrdinal = reader.GetOrdinal("Runtime");
            var averageUserScoreOrdinal = reader.GetOrdinal("AverageUserScore");


            while (reader.Read())
            {                
                movieName = reader.GetString(movieNameOrdinal);
                releaseYear = reader.GetInt32(releaseYearOrdinal);
                runtime = reader.GetInt32(runtimeOrdinal);
                averageUserScore = Math.Round(reader.GetDecimal(averageUserScoreOrdinal), 1);
                results.Add(new Movie(movieName, releaseYear, runtime, averageUserScore));
              
            }
            return results;

        }

        private static List<CrewMember> GetCrewMembersForMovie(string movieName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand($"EXEC Movies.GetCrewMembersForMovie @MovieName = N'{movieName}'", connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();

                    using (var reader = command.ExecuteReader()) return TranslateCrewMembers(reader);
                }
            }
        }

        private static List<CrewMember> TranslateCrewMembers(SqlDataReader reader)
        {
            List<CrewMember> crew = new List<CrewMember>();

            var firstNameOrdinal = reader.GetOrdinal("FirstName");
            var lastNameOrdinal = reader.GetOrdinal("LastName");
            var genreTypeOrdinal = reader.GetOrdinal("GenreType");

            while (reader.Read())
            {
                crew.Add(new CrewMember(
                    reader.GetString(firstNameOrdinal),
                    reader.GetString(lastNameOrdinal),
                    reader.GetString(genreTypeOrdinal)));
            }
            return crew;
        }

        public static FullTheater GetFullTheater(int theaterNum)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand($"EXEC Theaters.RetrieveAllInfoForTheater @TheaterNumber = N'{theaterNum}'", connection))
                {
                    command.CommandType = CommandType.Text;
                    
                    connection.Open();

                    using (var reader = command.ExecuteReader()) return TranslateFullTheater(reader);
                }
            }
        }

        private static FullTheater TranslateFullTheater(SqlDataReader reader)
        {
            string name;
            string address;
            string city;
            string state;
            string chainName;
            List<int> screenNums = new List<int>();
            List<string> screenTypes = new List<string>();
            List<DateTime> showDates = new List<DateTime>();
            List<string> movies = new List<string>();


            var nameOrdinal = reader.GetOrdinal("TheaterName");
            var addressOrdinal = reader.GetOrdinal("Address");
            var cityOrdinal = reader.GetOrdinal("City");
            var stateOrdinal = reader.GetOrdinal("State");
            var chainNameOrdinal = reader.GetOrdinal("TheaterChainName");
            var screenNumOrdinal = reader.GetOrdinal("ScreenNumber");
            var screenTypeOrdinal = reader.GetOrdinal("ScreenType");
            var showDateOrdinal = reader.GetOrdinal("DateTime");
            var movieNameOrdinal = reader.GetOrdinal("MovieName");

            reader.Read();
            name = reader.GetString(nameOrdinal);
            address = reader.GetString(addressOrdinal);
            city = reader.GetString(cityOrdinal);
            state = reader.GetString(stateOrdinal);
            chainName = reader.GetString(chainNameOrdinal);
            do
            {
                screenNums.Add(reader.GetInt32(screenNumOrdinal));
                screenTypes.Add(reader.GetString(screenTypeOrdinal));
                showDates.Add(reader.GetDateTime(showDateOrdinal));
                movies.Add(reader.GetString(movieNameOrdinal));
            } while (reader.Read());

            return new FullTheater(name, address, city, state, chainName, screenNums, screenTypes, showDates, movies);
        }

    }
}
