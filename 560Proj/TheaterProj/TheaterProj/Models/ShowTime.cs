using System;

namespace TheaterData.Models
{
    public class Showtime
    {
        public int ScreenID { get; }
        public int MovieID { get; }
        public string DateTime { get; }

        public Showtime(int screenID, int movieID, string dateTime)
        {
            ScreenID = screenID;
            MovieID = movieID;
            DateTime = dateTime;
        }
    }
}
