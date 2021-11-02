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
        public void StartApp()
        {
            User admin = new Admin("Sandra", "hejsan");
            admin.Users.Add(admin);
            Menu menu = new Menu();
            Costumes.StarterCostumes();
            while (true)
            {
                Console.CursorVisible = false;
                Console.Title = "The best costume rental place!";
                menu.MainMenu(Costumes.Costumes, menu, admin);

            }
        }
        public void RentACostume(List<Costume> costume, Menu menu, User user)
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
                        temp = costume.FindAll(c => c is Fairy);
                        DisplayCostumeSizeOptions(temp, menu, user);
                        continue;
                    case 1:
                        temp = costume.FindAll(c => c is Devil);
                        DisplayCostumeSizeOptions(temp, menu, user);
                        continue;
                    case 2:
                        temp = costume.FindAll(c => c is Superman);
                        DisplayCostumeSizeOptions(temp, menu, user);
                        continue;
                    case 3:
                        temp = costume.FindAll(c => c is Spiderman);
                        DisplayCostumeSizeOptions(temp, menu, user);
                        continue;
                    case 4:
                        temp = costume.FindAll(c => c is Vampire);
                        DisplayCostumeSizeOptions(temp, menu, user);
                        continue;
                    case 5:
                        temp = costume.FindAll(c => c is Witch);
                        DisplayCostumeSizeOptions(temp, menu, user);
                        continue;
                    case 6:

                        break;
                }
                break;
            }

        }
        public void DisplayCostumeSizeOptions(List<Costume> costume, Menu menu, User user)
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
            RentChosenCostume(costume, menu, user);
        }
        private void CreateMemberAccount(Costume costume, User user)
        {
            Console.Write("\tPlease enter your name: ");
            string userName = Console.ReadLine();
            Console.Write("\tCreate a password: ");
            string userPassword = Console.ReadLine();
            Member newMember = new Member(userName, userPassword, costume);
            user.Users.Add(newMember);
            Console.WriteLine(newMember.ToString());
            Console.ReadKey();
        }
        private void RentChosenCostume(List<Costume> costume, Menu menu, User user)
        {
            for (int i = 0; i < costume.Count;)
            {
                if (costume[menu.SelectedIndex].NumberInStock == 0)
                {
                    Console.WriteLine("\tThat costume is already rented at the moment, press any key to continue!");
                    Console.ReadKey();
                }
                else if (costume[menu.SelectedIndex].NumberInStock > 0)
                {
                    CreateMemberAccount(costume[menu.SelectedIndex], user);
                    costume[menu.SelectedIndex].NumberInStock--;
                }
                break;
            }
        }

    }
}
