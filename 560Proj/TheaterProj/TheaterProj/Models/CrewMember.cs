using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterData.Models
{
    public class CrewMember
    {
        public int CrewMemberID { get; }
        public int MovieID { get; }
        public PersonType PersonType { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public CrewMember(int crewMemberID, int movieID, PersonType personType, string firstName, string lastName)
        {
            CrewMemberID = crewMemberID;
            MovieID = movieID;
            PersonType = personType;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
