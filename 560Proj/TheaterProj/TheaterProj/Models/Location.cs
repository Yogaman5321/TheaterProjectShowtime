using System;

namespace TheaterData.Models
{
    public class Location
    {
        public int LocationID { get; }
        public string State { get; }
        public string Address { get; }
        public string City { get; }

        public Location(int locationID, string state, string address, string city)
        {
            LocationID = locationID;
            State = state;
            Address = address;
            City = city;
        }
    }
}