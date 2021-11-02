using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class User
    {
        public List<User> Users { get; set; } = new List<User>();
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
