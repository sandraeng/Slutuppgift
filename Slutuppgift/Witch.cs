using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Witch : Costume 
    {
        public Witch(string typeOfCostume, Size size, int numberInStock)
        {
            TypeOfCostume = typeOfCostume;
            Size = size;
            NumberInStock = numberInStock;
            IsAvailable = true;
        }
    }
}
