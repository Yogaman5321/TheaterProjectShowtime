using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheaterData.Models;

namespace TheaterProj
{
    public interface IShowTimeRepository
    {
        IList<Showtime> GetAllShowTimes();

        void AddShowTime(int screenID, DateTime date, int movieID);

    }
}
