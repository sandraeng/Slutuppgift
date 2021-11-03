using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    public class Costume
    {
        public string TypeOfCostume { get; set; }
        public Size Size { get; set; }
        public int NumberInStock { get; set; }
        public List<Costume> Costumes { get; set; } = new List<Costume>();

       
        public void StarterCostumes()
        {
            Costumes.Add(new Devil(typeOfCostume: "Devil", size: Size.S, numberInStock: 2));
            Costumes.Add(new Devil(typeOfCostume: "Devil", size: Size.M, numberInStock: 3));
            Costumes.Add(new Devil(typeOfCostume: "Devil", size: Size.XXL, numberInStock: 1));
            Costumes.Add(new Fairy(typeOfCostume: "Fairy", size: Size.M, numberInStock: 2));
            Costumes.Add(new Fairy(typeOfCostume: "Fairy", size: Size.L, numberInStock: 1));
            Costumes.Add(new Fairy(typeOfCostume: "Fairy", size: Size.XL, numberInStock: 1));
            Costumes.Add(new Spiderman(typeOfCostume: "Spiderman", size: Size.S, numberInStock: 2));
            Costumes.Add(new Spiderman(typeOfCostume: "Spiderman", size: Size.L, numberInStock: 2));
            Costumes.Add(new Spiderman(typeOfCostume: "Spiderman", size: Size.XL, numberInStock: 1));
            Costumes.Add(new Superman(typeOfCostume: "Superman", size: Size.M, numberInStock: 2));
            Costumes.Add(new Superman(typeOfCostume: "Superman", size: Size.L, numberInStock: 1));
            Costumes.Add(new Superman(typeOfCostume: "Superman", size: Size.XXL, numberInStock: 2));
            Costumes.Add(new Vampire(typeOfCostume: "Vampire", size: Size.S, numberInStock: 1));
            Costumes.Add(new Vampire(typeOfCostume: "Vampire", size: Size.M, numberInStock: 3));
            Costumes.Add(new Vampire(typeOfCostume: "Vampire", size: Size.L, numberInStock: 2));
            Costumes.Add(new Witch(typeOfCostume: "Witch", size: Size.L, numberInStock: 1));
            Costumes.Add(new Witch(typeOfCostume: "Witch", size: Size.XL, numberInStock: 1));
            Costumes.Add(new Witch(typeOfCostume: "Witch", size: Size.XXL, numberInStock: 2));
        }
        public override string ToString()
        {
            return $"\tType of costume: {TypeOfCostume}\n\t   Costume size: {Size}\n\t   Number in stock: {NumberInStock} \n";
        }
    }
}
