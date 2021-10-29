using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Menu
    {
        public int SelectedMenuIndex { get; set; }
        public string[] MenuOptions { get; set; }
        public string MenuTitle { get; set; }

        public Menu(string menuTitle, string[] menuOptions)
        {
            MenuTitle = menuTitle;
            MenuOptions = menuOptions;
            SelectedMenuIndex = 0;
        }
        private void DisplayCurrentMenu()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"\n\t{MenuTitle}\n");
            for (int i = 0; i < MenuOptions.Length; i++)
            {
                string currentOption = MenuOptions[i];
                string symbol;
                if (i == SelectedMenuIndex)
                {
                    symbol = ">>";
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    symbol = "  ";
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine($"\t{symbol} {currentOption}");
            }
            Console.ResetColor();
        }
        public int RunMenu()
        {
            ConsoleKey pressedKey;
            do
            {
                DisplayCurrentMenu();

                ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
                pressedKey = pressedKeyInfo.Key;
                if(pressedKey == ConsoleKey.UpArrow)
                {
                    SelectedMenuIndex--;
                    if(SelectedMenuIndex == -1)
                    {
                        SelectedMenuIndex = MenuOptions.Length - 1;
                    }
                }
                else if(pressedKey == ConsoleKey.DownArrow)
                {
                    SelectedMenuIndex++;
                    if (SelectedMenuIndex == MenuOptions.Length)
                    {
                        SelectedMenuIndex = 0;
                    }
                }

            } while (pressedKey != ConsoleKey.Enter);

            return SelectedMenuIndex;
        }
        
        public void RentalMenu()
        {
            string[] menuOptions = { "Fairy", "Devil", "Superman", "Spiderman", "Vampire", "Witch" };
            foreach (var option in menuOptions)
            {
                Console.WriteLine(option);
            }
        }
        public void CreateNewCostumeMenu()
        {
            string[] menuOptions = { "Fairy", "Devil", "Superman", "Spiderman", "Vampire", "Witch" };
            foreach (var option in menuOptions)
            {
                Console.WriteLine(option);
            }
        }
        public void MembersMenu()
        {
            string[] menuOptions = { "Order history", "Rented costume", "Log out" };
            foreach (var option in menuOptions)
            {
                Console.WriteLine(option);
            }
        }
        public void ReturnMenu()
        {
            string[] menuOptions = { "Rent a costume", "Return a costume", "Log in", "Admin" };
            foreach (var option in menuOptions)
            {
                Console.WriteLine(option);
            }
        }
    }
}
