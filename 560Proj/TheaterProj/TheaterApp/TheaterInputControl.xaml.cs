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
using TheaterData.Models;
using TheaterProj.Models;
using TheaterProj.TheaterApp.EventArgs;

namespace TheaterProj.TheaterApp
{
    /// <summary>
    /// Interaction logic for TheaterInputControl.xaml
    /// </summary>
    public partial class TheaterInputControl : UserControl
    {
        public event EventHandler<TheaterEventArgs>? TheaterSubmitted;

        public TheaterInputControl()
        {
            InitializeComponent();
        }

        public void SubmitButtonClickEventHandler(object? sender, RoutedEventArgs e)
        {
            
            try
            {
                int i = int.Parse(TheaterInput.Text);
                TheaterSubmitted?.Invoke(this, new TheaterEventArgs(QueryHandler.GetFullTheater(i)));
            }
            catch
            {
                MessageBox.Show("Input must be a valid theater number.");
            }
            
            
        }
    }
}
