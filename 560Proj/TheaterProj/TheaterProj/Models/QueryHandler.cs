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
        /*
        public void AddDate(DateTime date)
        {
            if (date == null) throw new ArgumentNullException("The date cannot be null");
            if (date <= DateTime.Now) throw new ArgumentException("The date cannot be the current time or in the past.");
            _showDate = date;
        }
        */

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
            List<MovieHolder> holder = new List<MovieHolder>();


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
                if (movieName == "") //The first iteration.
                {
                    movieName = reader.GetString(movieNameOrdinal);
                    releaseYear = reader.GetInt32(releaseYearOrdinal);
                    runtime = reader.GetInt32(runtimeOrdinal);
                    averageUserScore = Math.Round(reader.GetDecimal(averageUserScoreOrdinal), 1);
                }
                else if(movieName != reader.GetString(movieNameOrdinal)) //When the movie has changed to a different one, add to the MovieHolder and continue.
                {
                    holder.Add(new MovieHolder(movieName, releaseYear, runtime, averageUserScore));
                    movieName = reader.GetString(movieNameOrdinal);
                    releaseYear = reader.GetInt32(releaseYearOrdinal);
                    runtime = reader.GetInt32(runtimeOrdinal);
                    averageUserScore = Math.Round(reader.GetDecimal(averageUserScoreOrdinal), 1);

                }
                else //Gathering the different genres.
                {
                    //genres.Add(reader.GetString(genreOrdinal));
                }                
            }
            holder.Add(new MovieHolder(movieName, releaseYear, runtime, averageUserScore));
            foreach (MovieHolder mh in holder)
            {
                results.Add(new Movie(
                    mh.MovieName,
                    mh.ReleaseYear,
                    mh.Runtime,
                    mh.AverageUserScore));
            }
            return results;

        }

        private static List<CrewMember> GetCrewMembersForMovie(string movieName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetCrewMembersForMovie", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("MovieName", movieName);

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
                using (var command = new SqlCommand("RetrieveFullTheater", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("TheaterNumber", theaterNum);
                    
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


            var nameOrdinal = reader.GetOrdinal("TheaterName");
            var addressOrdinal = reader.GetOrdinal("Address");
            var cityOrdinal = reader.GetOrdinal("City");
            var stateOrdinal = reader.GetOrdinal("State");
            var chainNameOrdinal = reader.GetOrdinal("TheaterChainName");
            var screenNumOrdinal = reader.GetOrdinal("ScreenNumber");
            var screenTypeOrdinal = reader.GetOrdinal("ScreenType");
            var showDateOrdinal = reader.GetOrdinal("DateTime");

            if (!reader.Read()) throw new ArgumentException();
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
            } while (reader.Read());

            return new FullTheater(name, address, city, state, chainName, screenNums, screenTypes, showDates);
        }

    }
}
