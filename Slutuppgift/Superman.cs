using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Superman : Costume 
    {
        public Superman(string typeOfCostume, Size size, int numberInStock) 
        {
            TypeOfCostume = typeOfCostume;
            Size = size;
            NumberInStock = numberInStock;
            IsAvailable = true;
        }
    }
}
