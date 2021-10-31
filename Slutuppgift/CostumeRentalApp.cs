using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class CostumeRentalApp
    {
        //public Menu menu { get; set; } = new Menu();
        public Costume Costumes { get; set; } = new Costume();
        public void StartApp()
        {
            Admin admin = new Admin("Sandra", "hejsan");
            Menu menu = new Menu();
            Costumes.StarterCostumes();
            while (true)
            {
                Console.CursorVisible = false;
                Console.Title = "The best costume rental place!";
                menu.MainMenu(Costumes, menu, admin);

            }
        }
        public void RentACostume(Costume costume, Menu menu)
        {
            while (true)
            {
                menu.ClearScreen();
                List<Costume> temp = new List<Costume>();
                List<string> options = new List<string> { "Fairy", "Devil", "Superman", "Spiderman", "Vampire", "Witch", "Go Back" };
                menu.menuSetup = new MenuSetup("Rent a costume, chose what costume you would like to rent", options);
                menu.SelectedIndex = menu.menuSetup.DisplaytInteractivMenu();
                menu.ClearScreen();
                switch (menu.SelectedIndex)
                {
                    case 0:
                        temp = costume.Costumes.FindAll(c => c is Fairy);
                        DisplayCostumeSizeOptions(temp, menu);
                        continue;
                    case 1:
                        temp = costume.Costumes.FindAll(c => c is Devil);
                        DisplayCostumeSizeOptions(temp, menu);
                        continue;
                    case 2:
                        temp = costume.Costumes.FindAll(c => c is Superman);
                        DisplayCostumeSizeOptions(temp, menu);
                        continue;
                    case 3:
                        temp = costume.Costumes.FindAll(c => c is Spiderman);
                        DisplayCostumeSizeOptions(temp, menu);
                        continue;
                    case 4:
                        temp = costume.Costumes.FindAll(c => c is Vampire);
                        DisplayCostumeSizeOptions(temp, menu);
                        continue;
                    case 5:
                        temp = costume.Costumes.FindAll(c => c is Witch);
                        DisplayCostumeSizeOptions(temp, menu);
                        continue;
                    case 6:

                        break;
                }
                break;
            }

        }
        public void DisplayCostumeSizeOptions(List<Costume> costume, Menu menu)
        {
            List<string> options = new List<string>();
            foreach (var c in costume)
            {
                if (c is Fairy || c is Devil || c is Superman || c is Spiderman || c is Vampire || c is Witch)
                {
                    options.Add(c.ToString());
                }
            }
            menu.menuSetup = new MenuSetup("Rent a costume, chose what size you would like", options);
            menu.SelectedIndex = menu.menuSetup.DisplaytInteractivMenu();
            RentChosenCostume(costume, menu);
        }
        private void RentChosenCostume(List<Costume> costume, Menu menu)
        {
            for (int i = 0; i < costume.Count;)
            {
                if (!costume[menu.SelectedIndex].IsAvailable)
                {
                    Console.WriteLine("\tThat costume is already rented at the moment, press any key to continue!");
                    Console.ReadKey();
                }
                else if (costume[menu.SelectedIndex].NumberInStock > 0)
                {
                    costume[menu.SelectedIndex].NumberInStock--;
                }
                if (costume[menu.SelectedIndex].NumberInStock == 0)
                {
                    costume[menu.SelectedIndex].IsAvailable = false;
                    break;
                }
                break;
            }
        }

    }
}
