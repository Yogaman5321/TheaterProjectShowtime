using System;

namespace TheaterData.Models
{
    public class Theater
    {
        public int TheaterID { get; }
        public int LocationID { get; }
        public int TheaterChainID { get; }
        public string TheaterName { get; }

        public Theater(int theaterID, int locationID, int theaterChainID, string theaterName)
        {
            TheaterID = theaterID;
            LocationID = locationID;
            TheaterChainID = theaterChainID;
            TheaterName = theaterName;
        }
    }
}
