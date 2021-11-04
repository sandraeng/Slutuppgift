using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Member : User
    {
        public List<Costume> RentedCostume { get; set; } = new List<Costume>();
        public List<Costume> PreviouslyRentedCostumes { get; set; } = new List<Costume>();
        public string UserAsMember { get; set; }
        public Member(string userName, string password, List<Costume> rentedCostume)
        {
            UserAsMember = "Member";
            UserName = userName;
            Password = password;
            RentedCostume = rentedCostume;
        }
        
        public override string ToString()
        {
            return $"\tChosen username: {UserName}\n\tChosen password: {Password}";
        }
    }
}
