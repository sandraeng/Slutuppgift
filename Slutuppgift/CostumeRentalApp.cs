using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class CostumeRentalApp
    {
        public Menu menu { get; set; } = new Menu();
        public Costume Costumes { get; set; } = new Costume();
        public void StartApp()
        {
            Costumes.StarterCostumes();
            while (true)
            {
                Console.CursorVisible = false;
                Console.Title = "The best costume rental place!";
                menu.MainMenu(Costumes);

            }
        }
        
        
        
        private void Exit()
        {
            Console.WriteLine("Are you sure? If yes press ESCAPE, if no press any other key.");
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            if(pressedKey.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            
        }
        
    }
}
