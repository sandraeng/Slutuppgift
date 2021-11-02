using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Member : User
    {
        public Costume RentedCostume { get; set; }
        public Member(string userName, string password, Costume rentedCostume)
        {
            UserName = userName;
            Password = password;
            RentedCostume = rentedCostume;
        }
        public Member(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public override string ToString()
        {
            return $"Username: {UserName}\nPassword: {Password}\nRented costume: {RentedCostume.TypeOfCostume}\n\tSize:  {RentedCostume.Size}";
        }
    }
}
