using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterProj.Models
{
    public class DataCollection
    {

        public FullTheater Theater { get; set; }


        private ObservableCollection<Movie> _movies = QueryHandler.GetAllMovies();

        public ObservableCollection<Movie> Movies
        {
            get => _movies;

            set
            {
                _movies = value;
            }
        }


    }
}
