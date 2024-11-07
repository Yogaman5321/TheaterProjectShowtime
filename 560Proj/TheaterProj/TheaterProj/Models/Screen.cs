using System;

namespace TheaterData.Models
{
    public class Screen
    {
        public int ScreenID { get; }
        public ScreenType ScreenType { get; }
        public int TheaterID { get; }
        public int ScreenNumber { get; }

        public Screen(int screenID, ScreenType screenType, int theaterID, int screenNumber)
        {
            ScreenID = screenID;
            ScreenType = screenType;
            TheaterID = theaterID;
            ScreenNumber = screenNumber;
        }
    }
}
