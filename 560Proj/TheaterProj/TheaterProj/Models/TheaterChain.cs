using System;

namespace TheaterData.Models
{
    public class TheaterChain
    {
        public int TheaterChainID { get; }
        public string TheaterChainName { get; }
        
        public TheaterChain(int theaterChainID, string theaterChainName)
        {
            TheaterChainID = theaterChainID;
            TheaterChainName = theaterChainName;
        }
    }
}
