using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SchedulerButtonClickEventHandler(object? sender, RoutedEventArgs e)
        {
            SetDisplay(TheaterInputDisplay);
        }

        public void HomeButtonClickEventHandler(object? sender, RoutedEventArgs e)
        {
            SetDisplay(MainMenuDisplay);
        }


        /// <summary>
        /// Helper method for switching between controls in the MainWindow grid, row 1
        /// </summary>
        /// <param name="display">The UserControl to set visible</param>
        private void SetDisplay(UserControl display)
        {
            if (display == TheaterInputDisplay)
            {
                // show this one
                TheaterInputDisplay.Visibility = Visibility.Visible;

                // hide all others
                MainMenuDisplay.Visibility = Visibility.Hidden;
                ShowtimeSchedulerDisplay.Visibility = Visibility.Hidden;
            }
            else if (display == ShowtimeSchedulerDisplay)
            {
                // show this one
                ShowtimeSchedulerDisplay.Visibility = Visibility.Visible;

                // hide all others
                MainMenuDisplay.Visibility = Visibility.Hidden;
                TheaterInputDisplay.Visibility = Visibility.Hidden;
            }
            else
            {
                // show this one
                MainMenuDisplay.Visibility = Visibility.Visible;

                // hide all others
                TheaterInputDisplay.Visibility = Visibility.Hidden;
                ShowtimeSchedulerDisplay.Visibility = Visibility.Hidden;
            }
        }

    }
}