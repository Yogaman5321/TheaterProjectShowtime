using System;

namespace TheaterData.Models
{
    public class Movie
    {
        public int MovieID { get; }        
        public string MovieName { get; }
        public int ReleaseYear { get; }
        public int Runtime { get; }
        public decimal AverageUserScore { get; }
        public ContentRating ContentRating { get; }
        public GenreType GenreType { get; }

        //NOTE: WILL PUT IN PEOPLE IN THE FUTURE.

        public Movie(int movieID, string movieName, int releaseYear, int runtime, decimal averageUserScore, ContentRating contentRating, GenreType genreType)
        {
            MovieID = movieID;
            GenreType = genreType;
            MovieName = movieName;
            ReleaseYear = releaseYear;
            Runtime = runtime;
            AverageUserScore = averageUserScore;
            ContentRating = contentRating;
        }
    }
}