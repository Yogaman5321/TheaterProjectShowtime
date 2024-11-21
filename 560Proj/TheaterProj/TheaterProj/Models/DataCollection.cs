using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterProj.Models
{
    public class DataCollection
    {

        public FullTheater Theater { get; set; }


        public IEnumerable<Movie> Movies => QueryHandler.GetAllMovies();


    }
}
