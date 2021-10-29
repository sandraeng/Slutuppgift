using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Vampire : Costume 
    {
        public Vampire(string typeOfCostume, Size size, int numberInStock, bool isAvailable)
        {
            TypeOfCostume = typeOfCostume;
            Size = size;
            NumberInStock = numberInStock;
            IsAvailable = isAvailable;
        }
    }
}
