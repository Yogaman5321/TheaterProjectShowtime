using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterProj
{
    public class QueryHandler
    {
        private DateTime _showDate;

        private string _showMovie;

        public void AddDate(DateTime date)
        {
            if (date == null) throw new ArgumentNullException("The date cannot be null");
            if (date <= DateTime.Now) throw new ArgumentException("The date cannot be the current time or in the past.");
            _showDate = date;
        }

    }
}
