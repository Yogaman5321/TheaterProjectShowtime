﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheaterData.Models;
using TheaterProj.Models;
using TheaterProj.TheaterApp.EventArgs;

namespace TheaterProj.TheaterApp
{
    /// <summary>
    /// Interaction logic for ShowtimeSchedulerControl.xaml
    /// </summary>
    public partial class ShowtimeSchedulerControl : UserControl
    {
        public event EventHandler<RemoveShowtimeEventArgs>? RemoveShowtime;

        public ShowtimeSchedulerControl()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Removes a Showtime from the database
        /// </summary>
        public void RemoveShowtimeClickEventHandler(object? sender, RoutedEventArgs e)
        {
            //RemoveShowtime?.Invoke(this, new RemoveShowtimeEventArgs(showtime to remove) );
        }

        // we might not include this function
        public void EditShowtimeClickEventHandler(object? sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Stages a DateTime to be the DateTime for a new Showtime
        /// </summary>
        public void AddDateClickEventHandler(object? sender, RoutedEventArgs e)
        {
            // update corresponding TextBlock at bottom
            // send info to Add Showtime button
        }

        /// <summary>
        /// Stages a Movie to be the Movie for a new Showtime (DOUBLE CLICK LISTVIEW ITEM TO ADD)
        /// </summary>
        public void AddMovieClickEventHandler(object? sender, MouseButtonEventArgs e)
        {
            // update corresponding TextBlock at bottom
            // send info to Add Showtime button
        }

        /// <summary>
        /// Adds the Showtime given the information selected (displayed at the bottom)
        /// </summary>
        public void AddShowtimeClickEventHandler(object? sender, RoutedEventArgs e)
        {
            // maybe make AddShowtimeViewModel as DataContext of the AddShowtimeButton that collects the info from the other buttons
        }

        public void FillShowTimeData(FullTheater theater)
        {
            //
            if(DataContext is DataCollection dc)
            {
                if(dc.Theater is FullTheater ft)
                {
                    for(int i = 0; i < ft.ShowDates.Count; i++)
                    {
                        TextBlock text = new();
                        text.Text = $"Movie: {ft.MovieName[i]}\n{ft.ShowDates[i].ToString()}\nOn Screen {ft.Screens[i]}\n";
                        StackList.Children.Add(text);
                    }
                }
            }
        }
    }
}
