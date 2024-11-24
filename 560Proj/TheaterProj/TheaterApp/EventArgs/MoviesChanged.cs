using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheaterProj.Models;

namespace TheaterProj.TheaterApp.EventArgs
{
    public class MoviesChanged : RoutedEventArgs
    {
        public ObservableCollection<Movie> Movies { get; set; }

        public MoviesChanged(ObservableCollection<Movie> movies)
        {
            this.Movies = movies;
        }

    }
}
