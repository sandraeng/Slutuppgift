using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Admin : User
    {
        
        public Admin(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
