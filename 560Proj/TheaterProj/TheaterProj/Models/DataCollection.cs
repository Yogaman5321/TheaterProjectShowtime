using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterProj.Models
{
    public class DataCollection : INotifyCollectionChanged, INotifyPropertyChanged
    {

        public FullTheater Theater { get; set; }


        private ObservableCollection<Movie> _movies = QueryHandler.GetAllMovies();

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Movie> Movies
        {
            get => _movies;

            set
            {
                _movies = value;
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Movies)));
            }
        }


    }
}
