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
        public Member(string userName, string password, List<Costume> rentedCostume)
        {
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
