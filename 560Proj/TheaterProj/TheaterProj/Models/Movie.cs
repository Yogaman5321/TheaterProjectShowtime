using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterProj.Models
{
    public class Movie
    {
        public string MovieName { get; set; }

        public int ReleaseYear { get; set; }

        public int Runtime { get; set; }

        public decimal AverageUserScore { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<CrewMember> CrewMembers { get; set; }

        public Movie(string movieName, int releaseYear, int runtime, decimal averageScore, IEnumerable<string> genres, IEnumerable<CrewMember> crew)
        {
            this.MovieName = movieName;
            this.ReleaseYear = releaseYear;
            this.Runtime = runtime;
            this.AverageUserScore = averageScore;
            this.Genres = genres;
            this.CrewMembers = crew;
        }


    }
}
