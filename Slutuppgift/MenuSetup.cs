using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class MenuSetup
    {
        public int SelectedMenuIndex { get; set; }
        public List<string> MenuOptions { get; set; }
        public string MenuTitle { get; set; }

        public MenuSetup()
        {

        }
        
        public MenuSetup(string menuTitle, List<string> menuOptions)
        {
            MenuTitle = menuTitle;
            MenuOptions = menuOptions;
            SelectedMenuIndex = 0;
        }
        private void CurrentMenu()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"\n\t{MenuTitle}\n");
            for (int i = 0; i < MenuOptions.Count; i++)
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
        public int DisplaytInteractivMenu()
        {
            ConsoleKey pressedKey;
            do
            {
                CurrentMenu();

                ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
                pressedKey = pressedKeyInfo.Key;
                if (pressedKey == ConsoleKey.UpArrow)
                {
                    SelectedMenuIndex--;
                    if (SelectedMenuIndex == -1)
                    {
                        SelectedMenuIndex = MenuOptions.Count - 1;
                    }
                }
                else if (pressedKey == ConsoleKey.DownArrow)
                {
                    SelectedMenuIndex++;
                    if (SelectedMenuIndex == MenuOptions.Count)
                    {
                        SelectedMenuIndex = 0;
                    }
                }

            } while (pressedKey != ConsoleKey.Enter);

            return SelectedMenuIndex;
        }
    }
}
