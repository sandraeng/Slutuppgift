using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Fairy : Costume
    {
        public Fairy(string typeOfCostume, Size size, int numberInStock)
        {
            TypeOfCostume = typeOfCostume;
            Size = size;
            NumberInStock = numberInStock;
        }
    }
}
