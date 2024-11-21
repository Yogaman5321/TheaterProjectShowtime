using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterProj.Models
{
    public class FullTheater
    {
        public string TheaterName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string TheaterChainName { get; set; }

        public List<int> Screens { get; set; }

        public List<string> ScreenTypes { get; set; }

        public List<DateTime> ShowDates { get; set; }

        public FullTheater(string theaterName, string address, string city, string state, string theaterChainName, List<int> screens,
                                List<string> screenTypes, List<DateTime> showDates)
        {
            this.TheaterName = theaterName;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.TheaterChainName = theaterChainName;
            this.Screens = screens;
            this.ScreenTypes = screenTypes;
            this.ShowDates = showDates;
        }


    }
}
