using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        public Costume(string typeOfCostume, Size size, int numberInStock)
        {
            TypeOfCostume = typeOfCostume;
            Size = size;
            NumberInStock = numberInStock;
        }
        public Costume()
        {

        }
        public void StarterCostumes()
        {
            Costumes.AddRange(new Costume[] { new Costume(typeOfCostume: "Devil", size: Size.S, numberInStock: 2),
            new Costume (typeOfCostume: "Devil", size: Size.M, numberInStock: 3),
            new Costume(typeOfCostume: "Devil", size: Size.XXL, numberInStock: 1),
            new Costume(typeOfCostume: "Fairy", size: Size.M, numberInStock: 2),
            new Costume(typeOfCostume: "Fairy", size: Size.L, numberInStock: 1),
            new Costume(typeOfCostume: "Fairy", size: Size.XL, numberInStock: 1),
            new Costume(typeOfCostume: "Spiderman", size: Size.S, numberInStock: 2),
            new Costume(typeOfCostume: "Spiderman", size: Size.L, numberInStock: 2),
            new Costume(typeOfCostume: "Spiderman", size: Size.XL, numberInStock: 1),
            new Costume(typeOfCostume: "Superman", size: Size.M, numberInStock: 2),
            new Costume(typeOfCostume: "Superman", size: Size.L, numberInStock: 1),
            new Costume(typeOfCostume: "Superman", size: Size.XXL, numberInStock: 2),
            new Costume(typeOfCostume: "Vampire", size: Size.S, numberInStock: 1),
            new Costume(typeOfCostume: "Vampire", size: Size.M, numberInStock: 3),
            new Costume(typeOfCostume: "Vampire", size: Size.L, numberInStock: 2),
            new Costume(typeOfCostume: "Witch", size: Size.L, numberInStock: 1),
            new Costume(typeOfCostume: "Witch", size: Size.XL, numberInStock: 1),
            new Costume(typeOfCostume: "Witch", size: Size.XXL, numberInStock: 2)});
            

            var jsonString = JsonConvert.SerializeObject(Costumes);
            string filePath = @"C:\Code Skola\Slutuppgift\Slutuppgift\Costume.json";
            if(File.Exists(filePath) == false)
            {
                File.WriteAllText(filePath, jsonString);
            }
            else
            {
                File.Delete(filePath);
                File.WriteAllText(filePath, jsonString);
            }
        }
        public override string ToString()
        {
            return $"\tType of costume: {TypeOfCostume}\n\t   Costume size: {Size}\n\t   Number in stock: {NumberInStock} \n";
        }
    }
}
