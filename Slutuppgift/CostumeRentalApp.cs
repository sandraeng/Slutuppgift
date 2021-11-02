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
            bool exit = true;
            while (exit)
            {
                Console.Write("\tPlease enter your username: ");
                string userName = Console.ReadLine();
                for (int i = 0; i < user.Users.Count; i++)
                {
                    if (user.Users[i].UserName.ToUpper() == userName.ToUpper())
                    {
                        Console.WriteLine("That username is already in use, please enter a new one.");
                        break;
                    }
                    else if (user.Users[i].UserName.ToUpper() != userName.ToUpper() && i == user.Users.Count - 1)
                    {
                        Console.Write("\tCreate a password: ");
                        string userPassword = Console.ReadLine();
                        Member newMember = new Member(userName, userPassword, costume);
                        user.Users.Add(newMember);
                        Console.WriteLine(newMember.ToString());
                        Console.ReadKey();
                        exit = false;
                    }
                }
            }
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
        public void CreateNewCostumeMenu(List<Costume> costume, Menu menu)
        {
            menu.ClearScreen();
            List<string> options = new List<string> { "Fairy", "Devil", "Superman", "Spiderman", "Vampire", "Witch", "Go back" };
            menu.menuSetup = new MenuSetup("Add a new costume to inventory, chose what costume you would like to add", options);
            menu.SelectedIndex = menu.menuSetup.DisplaytInteractivMenu();
            switch (menu.SelectedIndex)
            {
                case 0:
                    Size tempSize = CostumeSizeToAdd(menu);
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c] is Fairy)
                        {
                            if ((costume[c] as Fairy).Size == tempSize)
                            {
                                costume[c].NumberInStock++;
                                break;
                            }
                        }
                        else if (c == costume.Count - 1)
                        {
                            costume.Add(new Fairy("Fairy", tempSize, 1));
                            break;
                        }
                    }
                    break;
                case 1:
                    tempSize = CostumeSizeToAdd(menu);
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c] is Devil)
                        {
                            if ((costume[c] as Devil).Size == tempSize)
                            {
                                costume[c].NumberInStock++;
                                break;
                            }
                        }
                        else if (c == costume.Count - 1)
                        {
                            costume.Add(new Devil("Devil", tempSize, 1));
                            break;
                        }
                    }
                    break;
                case 2:
                    tempSize = CostumeSizeToAdd(menu);
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c] is Superman)
                        {
                            if ((costume[c] as Superman).Size == tempSize)
                            {
                                costume[c].NumberInStock++;
                                break;
                            }
                        }
                        else if (c == costume.Count - 1)
                        {
                            costume.Add(new Superman("Superman", tempSize, 1));
                            break;
                        }
                    }
                    break;
                case 3:
                    tempSize = CostumeSizeToAdd(menu);
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c] is Spiderman)
                        {
                            if ((costume[c] as Spiderman).Size == tempSize)
                            {
                                costume[c].NumberInStock++;
                                break;
                            }
                        }
                        else if (c == costume.Count - 1)
                        {
                            costume.Add(new Spiderman("Spiderman", tempSize, 1));
                            break;
                        }
                    }
                    break;
                case 4:
                    tempSize = CostumeSizeToAdd(menu);
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c] is Vampire)
                        {
                            if ((costume[c] as Vampire).Size == tempSize)
                            {
                                costume[c].NumberInStock++;
                                break;
                            }
                        }
                        else if (c == costume.Count - 1)
                        {
                            costume.Add(new Vampire("Vampire", tempSize, 1));
                            break;
                        }
                    }
                    break;
                case 5:
                    tempSize = CostumeSizeToAdd(menu);
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c] is Witch)
                        {
                            if ((costume[c] as Witch).Size == tempSize)
                            {
                                costume[c].NumberInStock++;
                                break;
                            }
                        }
                        else if (c == costume.Count - 1)
                        {
                            costume.Add(new Witch("Witch", tempSize, 1));
                            break;
                        }
                    }
                    break;
                case 6:
                    break;
            }
        }
        public Size CostumeSizeToAdd(Menu menu)
        {
            menu.ClearScreen();
            Size size = Size.S;
            List<string> options = new List<string> { "S", "M", "L", "XL", "XXL" };
            menu.menuSetup = new MenuSetup("Chose what size the new costume has: ", options);
            menu.SelectedIndex = menu.menuSetup.DisplaytInteractivMenu();
            switch (menu.SelectedIndex)
            {
                case 0:
                    size = Size.S;
                    break;
                case 1:
                    size = Size.M;
                    break;
                case 2:
                    size = Size.L;
                    break;
                case 3:
                    size = Size.XL;
                    break;
                case 4:
                    size = Size.XXL;
                    break;
            }
            return size;
        }
    }
}
