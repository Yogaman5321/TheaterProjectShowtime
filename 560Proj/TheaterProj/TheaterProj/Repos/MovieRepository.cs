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
    public class MovieRepository : IMovieRepository
    {
        //NOTE: You MUST run the GetConnectionString script in order to get the correct connection string.
        //Just copy and paste it here. If you get an error in the string about an escape command, just put an extra \ by it.
        private readonly string _connectionString = "data source=Hunter\\LOCALDB#C0445AB7;initial catalog=master;trusted_connection=true";

        public IList<Movie> _MovieList;

        public MovieRepository()
        {
            _MovieList = GetAllMovies();
        }

        public IList<Movie> FilterByGenre(GenreType genre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Movies.GetMoviesByGenre", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("GenreTypeID", (int)genre);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateMovies(reader);
                }
            }
        }

        public IList<Movie> FilterByName(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Movies.GetMoviesByGenre", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("MovieName", $"{name}%");

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateMovies(reader);
                }
            }
        }

        public IList<Movie> FilterByRating(ContentRating rating)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Movies.GetMoviesByGenre", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("ContentRatingID", (int)rating);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateMovies(reader);
                }
            }
        }

        public IList<Movie> GetAllMovies()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Movies.GetAllMovies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateMovies(reader);
                }
            }
        }


        //IDK if we need this method but it's here anyways.
        private Movie TranslateMovie(SqlDataReader reader)
        {
            
            var movieIDOrdinal = reader.GetOrdinal("MovieID");
            var movieNameOrdinal = reader.GetOrdinal("MovieName");
            var releaseYearOrdinal = reader.GetOrdinal("ReleaseYear");
            var runTimeOrdinal = reader.GetOrdinal("Runtime");
            var averageUserScoreOrdinal = reader.GetOrdinal("AverageUserScore");
            var genreTypeIDOrdinal = reader.GetOrdinal("GenreTypeID");
            var contentRatingIDOrdinal = reader.GetOrdinal("ContentRatingID");

            if (!reader.Read())
                return null;

            return new Movie(
                   reader.GetInt32(movieIDOrdinal),
                   reader.GetString(movieNameOrdinal),
                   reader.GetInt32(releaseYearOrdinal),
                   reader.GetInt32(runTimeOrdinal),
                   reader.GetDecimal(averageUserScoreOrdinal),
                   (ContentRating)contentRatingIDOrdinal,
                   (GenreType)genreTypeIDOrdinal);
        }

        private IList<Movie> TranslateMovies(SqlDataReader reader)
        {
            var movies = new List<Movie>();

            var movieIDOrdinal = reader.GetOrdinal("MovieID");
            var movieNameOrdinal = reader.GetOrdinal("MovieName");
            var releaseYearOrdinal = reader.GetOrdinal("ReleaseYear");
            var runTimeOrdinal = reader.GetOrdinal("Runtime");
            var averageUserScoreOrdinal = reader.GetOrdinal("AverageUserScore");
            var genreTypeIDOrdinal = reader.GetOrdinal("GenreTypeID");
            var contentRatingIDOrdinal = reader.GetOrdinal("ContentRatingID");

            while (reader.Read())
            {
                movies.Add(new Movie(
                   reader.GetInt32(movieIDOrdinal),
                   reader.GetString(movieNameOrdinal),
                   reader.GetInt32(releaseYearOrdinal),
                   reader.GetInt32(runTimeOrdinal),
                   reader.GetDecimal(averageUserScoreOrdinal),
                   (ContentRating)contentRatingIDOrdinal,
                   (GenreType)genreTypeIDOrdinal));
                   
            }

            return movies;
        }
    }
}
