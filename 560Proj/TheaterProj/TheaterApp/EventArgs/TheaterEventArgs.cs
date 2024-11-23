using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheaterProj.Models;

namespace TheaterProj.TheaterApp.EventArgs
{
    public class TheaterEventArgs : RoutedEventArgs
    {
        public FullTheater Theater { get; set; }

        public TheaterEventArgs(FullTheater theater)
        {
            this.Theater = theater;
        }
    }
}
