﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Spiderman : Costume 
    {
        public Spiderman(string typeOfCostume, Size size, int numberInStock, bool isAvailable)
        {
            TypeOfCostume = typeOfCostume;
            Size = size;
            NumberInStock = numberInStock;
            IsAvailable = isAvailable;
        }
    }
}
