using System;
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

namespace TheaterProj.TheaterApp
{
    /// <summary>
    /// Interaction logic for AggregatingQueriesControl.xaml
    /// </summary>
    public partial class AggregatingQueriesControl : UserControl
    {
        public AggregatingQueriesControl()
        {
            InitializeComponent();
        }

        public void HighestRatedClickEventHandler(object? sender, RoutedEventArgs e)
        {
            SetDisplay(HighestRatedDisplay);
        }

        public void GenreCountClickEventHandler(object? sender, RoutedEventArgs e)
        {
            SetDisplay(GenreCountDisplay);
        }

        public void ScreenCountClickEventHandler(object? sender, RoutedEventArgs e)
        {
            SetDisplay(ScreenCountDisplay);
        }

        public void MovieCountClickEventHandler(object? sender, RoutedEventArgs e)
        {
            SetDisplay(MovieCountDisplay);
        }

        /// <summary>
        /// Helper method for switching between controls in the MainWindow grid, row 1
        /// </summary>
        /// <param name="display">The UserControl to set visible</param>
        private void SetDisplay(UserControl display)
        {
            if (display == GenreCountDisplay)
            {
                // show this one
                GenreCountDisplay.Visibility = Visibility.Visible;

                // hide all others
                MovieCountDisplay.Visibility = Visibility.Hidden;
                ScreenCountDisplay.Visibility = Visibility.Hidden;
                HighestRatedDisplay.Visibility = Visibility.Hidden;
            }
            else if (display == MovieCountDisplay)
            {
                // show this one
                MovieCountDisplay.Visibility = Visibility.Visible;

                // hide all others
                GenreCountDisplay.Visibility = Visibility.Hidden;
                ScreenCountDisplay.Visibility = Visibility.Hidden;
                HighestRatedDisplay.Visibility = Visibility.Hidden;
            }
            else if (display == ScreenCountDisplay)
            {
                // show this one
                ScreenCountDisplay.Visibility = Visibility.Visible;

                // hide all others
                GenreCountDisplay.Visibility = Visibility.Hidden;
                MovieCountDisplay.Visibility = Visibility.Hidden;
                HighestRatedDisplay.Visibility = Visibility.Hidden;
            }
            else if (display == HighestRatedDisplay)
            {
                // show this one
                HighestRatedDisplay.Visibility = Visibility.Visible;

                // hide all others
                GenreCountDisplay.Visibility = Visibility.Hidden;
                MovieCountDisplay.Visibility = Visibility.Hidden;
                ScreenCountDisplay.Visibility = Visibility.Hidden;
            }
            else
            {
                // hide all
                GenreCountDisplay.Visibility = Visibility.Hidden;
                MovieCountDisplay.Visibility = Visibility.Hidden;
                ScreenCountDisplay.Visibility = Visibility.Hidden;
                HighestRatedDisplay.Visibility = Visibility.Hidden;
            }
        }
    }
}
