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
                        break;
                    case 1:
                        temp = costume.FindAll(c => c is Devil);
                        DisplayCostumeSizeOptions(temp, menu, user);
                        break;
                    case 2:
                        temp = costume.FindAll(c => c is Superman);
                        DisplayCostumeSizeOptions(temp, menu, user);
                        break;
                    case 3:
                        temp = costume.FindAll(c => c is Spiderman);
                        DisplayCostumeSizeOptions(temp, menu, user);
                        break;
                    case 4:
                        temp = costume.FindAll(c => c is Vampire);
                        DisplayCostumeSizeOptions(temp, menu, user);
                        break;
                    case 5:
                        temp = costume.FindAll(c => c is Witch);
                        DisplayCostumeSizeOptions(temp, menu, user);
                        break;
                    case 6:
                        break;
                }
                for (int i = 0; i < costume.Count; i++)
                {
                    if(costume[i].NumberInStock == 0)
                    {
                        costume.RemoveAt(i);
                    }
                }
                break;
            }
        }
        public void DisplayCostumeSizeOptions(List<Costume> costume, Menu menu, User user)
        {
            List<string> options = new List<string>();
            foreach (var c in costume)
            {
                options.Add(c.ToString());
            }
            options.Add("\t Go back");
            menu.menuSetup = new MenuSetup("Rent a costume, chose what size you would like", options);
            menu.SelectedIndex = menu.menuSetup.DisplaytInteractivMenu();
            Console.WriteLine("");
            RentChosenCostume(costume, menu, user);
        }
        private bool CreateMemberAccount(Costume costume, User user, Menu menu)
        {
            while (true)
            {
                Start:
                menu.ClearScreen();
                Console.WriteLine($"\n\tChosen costume:\n\tType of costume: {costume.TypeOfCostume}\n\tSize: {costume.Size}\n");
                Console.WriteLine("\n\tCreate a username that is at least 3 letters long.");
                Console.CursorVisible = true;
                Console.Write("\n\tUsername: ");
                string userName = Console.ReadLine();
                for (int i = 0; i < user.Users.Count; i++)
                {
                    if (user.Users[i].UserName.ToUpper() == userName.ToUpper())
                    {
                        Console.WriteLine("\n\tThat username is already in use, press ENTER to try again or press ESCAPE to go back");
                        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                        if(keyPressed.Key == ConsoleKey.Enter)
                        {
                            goto Start;
                        }
                        else if(keyPressed.Key == ConsoleKey.Escape)
                        {
                            return false;
                        }
                    }
                    else if(userName.Length < 3)
                    {
                        Console.CursorVisible = false;
                        Console.WriteLine("\n\tThat username is to short, press ENTER to try again or press ESCAPE to go back");
                        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                        if (keyPressed.Key == ConsoleKey.Enter)
                        {
                            goto Start;
                        }
                        else if (keyPressed.Key == ConsoleKey.Escape)
                        {
                            return false;
                        }
                    }
                    else if (user.Users[i].UserName.ToUpper() != userName.ToUpper() && i == user.Users.Count - 1)
                    {
                        while (true)
                        {
                            Console.SetCursorPosition(0, 10);
                            Console.Write("\tCreate a password: ");
                            string userPassword = Console.ReadLine();
                            if(userPassword.Length < 3)
                            {
                                Console.CursorVisible = false;
                                Console.WriteLine("\n\tThat password is to short, press any key to try again");
                                Console.ReadKey();
                                Console.SetCursorPosition(0, 12);
                                Console.WriteLine("\t                                                         ");
                                Console.CursorVisible = true;
                            }
                            else
                            {
                                Console.CursorVisible = false;
                                List<Costume> listCostume = new List<Costume>();
                                listCostume.Add(costume);
                                Member newMember = new Member(userName, userPassword, listCostume);
                                user.Users.Add(newMember);
                                Console.WriteLine(newMember.ToString());
                                Console.WriteLine("\n\tYou have succesfully rented chosen costume");
                                Console.ReadKey();
                                break;
                            }
                        }
                        break;
                    }
                }
                break;
            }
            return true;
        }
        private void RentChosenCostumeMember(List<Costume> costume, Menu menu, User user)
        {
            while (true)
            {
                Start:
                menu.ClearScreen();
                Console.CursorVisible = true;
                Console.WriteLine("\n\tEnter your info to rent the chosen costume\n");
                Console.Write("\n\tUsername: ");
                string inputUserName = Console.ReadLine();
                Console.Write("\n\tPassword: ");
                string inputPassword = Console.ReadLine();
                Console.CursorVisible = false;
                for (int i = 0; i < user.Users.Count; i++)
                {
                    if ((user.Users[i] is Member)
                        && inputUserName.ToUpper() == user.Users[i].UserName.ToUpper()
                        && inputPassword.ToUpper() == user.Users[i].Password.ToUpper())
                    {

                        (user.Users[i] as Member).RentedCostume.Add(costume[menu.SelectedIndex]);
                        costume[menu.SelectedIndex].NumberInStock--;
                        Console.WriteLine($"\n\tYou have succesfully rented:\n\tCostume type: {costume[menu.SelectedIndex].TypeOfCostume}\n\tIn size: {costume[menu.SelectedIndex].Size}\n\n\tPress any key to continue");
                        Console.ReadKey();
                        break;
                    }
                    else if ((user.Users[i] is Member) && (inputUserName.ToUpper() != user.Users[i].UserName.ToUpper()
                            || inputPassword.ToUpper() != user.Users[i].Password.ToUpper()) && i == user.Users.Count - 1
                            || !(user.Users[i] is Member) && i == user.Users.Count - 1)
                    {
                        Console.WriteLine("\n\tInvalid username or Password, press ENTER to try again or press any other key to go back");
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.Enter)
                        {
                            goto Start;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                break;
            }
        }
        private void RentChosenCostume(List<Costume> costume, Menu menu, User user)
        {
            while (true)
            {
                for (int i = 0; i < costume.Count;)
                {
                    if(menu.SelectedIndex == costume.Count)
                    {
                        break;
                    }
                    else if (costume[menu.SelectedIndex].NumberInStock > 0)
                    {
                        menu.ClearScreen();
                        Console.WriteLine($"\n\tChosen costume:\n\tType of costume: {costume[menu.SelectedIndex].TypeOfCostume}\n\tSize: {costume[menu.SelectedIndex].Size}\n");
                        Console.WriteLine("\n\tDo you already have a members account? press 'Y' for yes or 'N' for no");
                        Console.WriteLine("\n\tPress ESCAPE to go back");
                        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                        if (keyPressed.Key == ConsoleKey.Y)
                        {
                            RentChosenCostumeMember(costume, menu, user);
                            break;
                        }
                        else if (keyPressed.Key == ConsoleKey.N)
                        {
                            if(keyPressed.Key == ConsoleKey.Escape)
                            {
                                break;
                            }
                            else
                            {
                                bool controll = CreateMemberAccount(costume[menu.SelectedIndex], user, menu);
                                if (controll) 
                                { 
                                    costume[menu.SelectedIndex].NumberInStock--;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else if (keyPressed.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    break;
                }
                break;
            }
        }
        public void ReturnACostume(List<Costume> costume, User user, Menu menu)
        {
            while (true)
            {
                menu.ClearScreen();
                List<string> options = new List<string>();
                for (int i = 0; i < (user as Member).RentedCostume.Count; i++)
                {
                    options.Add($"Type of costume: {(user as Member).RentedCostume[i].TypeOfCostume} \n\t   Size: {(user as Member).RentedCostume[i].Size}\n");
                }
                options.Add("\t Go Back");
                menu.menuSetup = new MenuSetup("Which costume do you want to return", options);
                menu.SelectedIndex = menu.menuSetup.DisplaytInteractivMenu();
                if (menu.SelectedIndex == (user as Member).RentedCostume.Count)
                {
                    break;
                }
                else if ((user as Member).RentedCostume.Count == 0)
                {
                    Console.WriteLine("\n\tYou have no costume to return!");
                }
                else
                {
                    if (costume.Contains((user as Member).RentedCostume[menu.SelectedIndex]))
                    {
                        for (int i = 0; i < costume.Count; i++)
                        {
                            if (costume[i] == (user as Member).RentedCostume[menu.SelectedIndex])
                            {
                                costume[i].NumberInStock++;
                                break;
                            }
                        }
                        (user as Member).RentedCostume.RemoveAt(menu.SelectedIndex);
                    }
                    else
                    {
                        (user as Member).RentedCostume[menu.SelectedIndex].NumberInStock = 1;
                        costume.Add((user as Member).RentedCostume[menu.SelectedIndex]);
                        (user as Member).RentedCostume.RemoveAt(menu.SelectedIndex);
                    }
                }
                break;
            }
            SortAllCostumes(costume);
        }
        public void CreateNewCostumeMenu(List<Costume> costume, Menu menu)
        {
            menu.ClearScreen();
            bool controll;
            List<Costume> temp = new List<Costume>();
            List<string> options = new List<string> { "Fairy", "Devil", "Superman", "Spiderman", "Vampire", "Witch", "Go back" };
            menu.menuSetup = new MenuSetup("Add a new costume to inventory, chose what costume you would like to add", options);
            menu.SelectedIndex = menu.menuSetup.DisplaytInteractivMenu();
            switch (menu.SelectedIndex)
            {
                case 0:
                    Size tempSize = CostumeSizeToAdd(menu);
                    temp = costume.FindAll(c => c is Fairy);
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Fairy("Fairy", tempSize, 1));
                    }
                    break;
                case 1:
                    tempSize = CostumeSizeToAdd(menu);
                    temp = costume.FindAll(c => c is Devil);
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Devil("Devil", tempSize, 1));
                    }
                    break;
                case 2:
                    tempSize = CostumeSizeToAdd(menu);
                    temp = costume.FindAll(c => c is Superman);
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Superman("Superman", tempSize, 1));
                    }
                    break;
                case 3:
                    tempSize = CostumeSizeToAdd(menu);
                    temp = costume.FindAll(c => c is Spiderman);
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Spiderman("Spiderman", tempSize, 1));
                    }
                    break;
                case 4:
                    tempSize = CostumeSizeToAdd(menu);
                    temp = costume.FindAll(c => c is Vampire);
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Vampire("Vampire", tempSize, 1));
                    }
                    break;
                case 5:
                    tempSize = CostumeSizeToAdd(menu);
                    temp = costume.FindAll(c => c is Witch);
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Witch("Witch", tempSize, 1));
                    }
                    break;
                case 6:
                    break;
            }
            SortAllCostumes(costume);
        }
        private bool CheckIfCostumeSizeExist(List<Costume> costume, Size tempSize)
        {
            for (int c = 0; c < costume.Count; c++)
            {
                if (costume[c].Size == tempSize)
                {
                    costume[c].NumberInStock++;
                    return true;
                }
            }
            return false;
        }
        private List<Costume> SortAllCostumes(List<Costume> costume)
        {
            var sortList = costume.OrderBy(c => c.TypeOfCostume).ThenBy(c => c.Size).ToList();
            costume.Clear();
            costume.AddRange(sortList);
            return costume;
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
