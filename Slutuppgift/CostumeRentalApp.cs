using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class CostumeRentalApp
    {
        public Costume Costumes { get; set; } = new Costume();
        public int SelectedIndex { get; set; }
        public void StartApp()
        {
            Costumes.StarterCostumes();
            while (true)
            {
                Console.CursorVisible = false;
                Console.Title = "The best costume rental place!";
                MainMenu();

            }
        }
        private void MainMenu()
        {
            ClearScreen();
            string[] options = { "Rent a costume", "Return a costume", "Log in", "Admin", "Exit" };
            Menu startMenu = new Menu("Costume rental", options);
            SelectedIndex = startMenu.RunMenu();
            switch (SelectedIndex)
            {
                case 0:
                    RentACostume();
                    ClearScreen();
                    break;
                case 1:
                    ReturnACostume();
                    break;
                case 2:
                    LogIn();
                    break;
                case 3:
                    Admin();
                    break;
                case 4:
                    Exit();
                    break;
            }
        }
        private void RentACostume()
        {
            
            Costumes.DisplayAllCostumes();
            Console.ReadKey();

        }
        private void ReturnACostume()
        {

        }
        private void LogIn()
        {

        }
        private void Admin()
        {

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
        private void ClearScreen()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(@"                                                                                           
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                            
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            ");
        }
    }
}
