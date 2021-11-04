using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class User
    {
        public List<Member> Members { get; set; } = new List<Member>();

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
