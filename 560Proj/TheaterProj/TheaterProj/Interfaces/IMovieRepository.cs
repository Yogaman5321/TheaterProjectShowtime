using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheaterData.Models;

namespace TheaterProj
{
    public interface IMovieRepository
    {
        IList<Movie> GetAllMovies();

        IList<Movie> FilterByGenre(GenreType genre);

        IList<Movie> FilterByRating(ContentRating rating);

        IList<Movie> FilterByName(string name);

    }
}
