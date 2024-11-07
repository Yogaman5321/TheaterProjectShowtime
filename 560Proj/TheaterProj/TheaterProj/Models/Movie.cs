using System;

namespace TheaterData.Models
{
    public class Movie
    {
        public int MovieID { get; }
        public GenreType GenreType { get; }
        public string MovieName { get; }
        public int ReleaseYear { get; }
        public int Runtime { get; }
        public decimal AverageUserScore { get; }

        public Movie(int movieID, GenreType genreType, string movieName, int releaseYear, int runtime, decimal averageUserScore)
        {
            MovieID = movieID;
            GenreType = genreType;
            MovieName = movieName;
            ReleaseYear = releaseYear;
            Runtime = runtime;
            AverageUserScore = averageUserScore;
        }
    }
}
