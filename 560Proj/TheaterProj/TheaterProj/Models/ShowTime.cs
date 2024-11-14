using System;

namespace TheaterData.Models
{
    public class Showtime
    {
        public int ScreenID { get; }
        public int MovieID { get; }
        public DateTime DateTime { get; }

        public Showtime(int screenID, int movieID, DateTime dateTime)
        {
            ScreenID = screenID;
            MovieID = movieID;
            DateTime = dateTime;
        }
    }
}
