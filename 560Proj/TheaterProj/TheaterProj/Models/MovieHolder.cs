using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterProj.Models
{
    /// <summary>
    /// This is used when creating the collection of movies.
    /// </summary>
    public class MovieHolder
    {
        public string MovieName { get; set; }

        public int ReleaseYear { get; set; }

        public int Runtime { get; set; }

        public decimal AverageUserScore { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public MovieHolder(string movieName, int releaseYear, int runtime, decimal userScore, IEnumerable<string> genres)
        {
            this.MovieName = movieName;
            this.ReleaseYear = releaseYear;
            this.Runtime = runtime;
            this.AverageUserScore = userScore;
            this.Genres = genres;
        }

    }
}
