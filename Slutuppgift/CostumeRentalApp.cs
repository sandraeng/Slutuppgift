using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            User user = new Admin("Sandra", "hejsan");
            Menu menu = new Menu();
            string filePath = @"C:\Code Skola\Slutuppgift\Slutuppgift\Costume.json";
            if (File.Exists(filePath) == false)
            {
                Costumes.StarterCostumes();
            }
            else
            {
                string jsonString = File.ReadAllText(filePath);
                Costumes.Costumes = JsonConvert.DeserializeObject<List<Costume>>(jsonString);
            }
            filePath = @"C:\Code Skola\Slutuppgift\Slutuppgift\Member.json";
            if (File.Exists(filePath) == false)
            {
                SerializeMembers(user.Members);
            }
            else
            {
                string jsonString = File.ReadAllText(filePath);
                user.Members = JsonConvert.DeserializeObject<List<Member>>(jsonString);
            }
            while (true)
            {
                Console.CursorVisible = false;
                Console.Title = "The best costume rental place!";
                menu.MainMenu(Costumes.Costumes, menu, user);
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
                        temp = costume.FindAll(c => c.TypeOfCostume == "Fairy");
                        DisplayCostumeSizeOptions(temp, menu, user);
                        break;
                    case 1:
                        temp = costume.FindAll(c => c.TypeOfCostume == "Devil");
                        DisplayCostumeSizeOptions(temp, menu, user);
                        break;
                    case 2:
                        temp = costume.FindAll(c => c.TypeOfCostume == "Superman");
                        DisplayCostumeSizeOptions(temp, menu, user);
                        break;
                    case 3:
                        temp = costume.FindAll(c => c.TypeOfCostume == "Spiderman");
                        DisplayCostumeSizeOptions(temp, menu, user);
                        break;
                    case 4:
                        temp = costume.FindAll(c => c.TypeOfCostume == "Vampire");
                        DisplayCostumeSizeOptions(temp, menu, user);
                        break;
                    case 5:
                        temp = costume.FindAll(c => c.TypeOfCostume == "Witch");
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
            SerializeCostumes(costume);
            SerializeMembers(user.Members);
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
        private void RentChosenCostume(List<Costume> costume, Menu menu, User user)
        {
            while (true)
            {
                for (int i = 0; i < costume.Count;)
                {
                    if (menu.SelectedIndex == costume.Count)
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
                            if (keyPressed.Key == ConsoleKey.Escape)
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
        private bool CreateMemberAccount(Costume costume, User user, Menu menu)
        {
            while (true)
            {
                Start:
                menu.ClearScreen();
                Console.WriteLine($"\n\tChosen costume:\n\tType of costume: {costume.TypeOfCostume}\n\tSize: {costume.Size}\n");
                Console.WriteLine("\n\tCreate a username and a password that is at least 3 letters long.");
                Console.CursorVisible = true;
                Console.Write("\n\tUsername: ");
                string userName = Console.ReadLine();
                for (int i = 0; i <= user.Members.Count; i++)
                {
                    if(user.Members.Count != 0)
                    {
                        if (user.Members[i].UserName.ToUpper() == userName.ToUpper())
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
                    else if (user.Members.Count == 0 || (user.Members[i].UserName.ToUpper() != userName.ToUpper() && i == user.Members.Count - 1))
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
                                user.Members.Add(newMember);
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
                if (user.Members.Count == 0)
                {
                    menu.ClearScreen();
                    Console.WriteLine("\n\tThere is no members listed, why dont you become our first!\n\tPress any key to go back to main meny.");
                    Console.ReadKey();
                }
                else
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
                    for (int i = 0; i < user.Members.Count; i++)
                    {
                    
                        if ((user.Members[i] is Member)
                            && inputUserName.ToUpper() == user.Members[i].UserName.ToUpper()
                            && inputPassword.ToUpper() == user.Members[i].Password.ToUpper())
                        {

                            (user.Members[i] as Member).RentedCostume.Add(costume[menu.SelectedIndex]);
                            costume[menu.SelectedIndex].NumberInStock--;
                            Console.WriteLine($"\n\tYou have succesfully rented:\n\tCostume type: {costume[menu.SelectedIndex].TypeOfCostume}\n\tIn size: {costume[menu.SelectedIndex].Size}\n\n\tPress any key to continue");
                            Console.ReadKey();
                            break;
                        }
                        else if ((user.Members[i] is Member) && (inputUserName.ToUpper() != user.Members[i].UserName.ToUpper()
                                || inputPassword.ToUpper() != user.Members[i].Password.ToUpper()) && i == user.Members.Count - 1
                                || !(user.Members[i] is Member) && i == user.Members.Count - 1)
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
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c].TypeOfCostume == (user as Member).RentedCostume[menu.SelectedIndex].TypeOfCostume && costume[c].Size == (user as Member).RentedCostume[menu.SelectedIndex].Size)
                        {
                            
                            costume[c].NumberInStock++;
                            (user as Member).RentedCostume.RemoveAt(menu.SelectedIndex);
                            break;
                        }
                        else if(c == costume.Count - 1)
                        {
                            (user as Member).RentedCostume[menu.SelectedIndex].NumberInStock = 1;
                            costume.Add((user as Member).RentedCostume[menu.SelectedIndex]);
                            (user as Member).RentedCostume.RemoveAt(menu.SelectedIndex);
                            break;
                        }
                    }
                }
                break;
            }
            SortAllCostumes(costume);
            SerializeCostumes(costume);
            SerializeMembers(user.Members);
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
                    temp = costume.FindAll(c => c.TypeOfCostume == "Fairy");
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Costume("Fairy", tempSize, 1));
                    }
                    break;
                case 1:
                    tempSize = CostumeSizeToAdd(menu);
                    temp = costume.FindAll(c => c.TypeOfCostume == "Devil");
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Costume("Devil", tempSize, 1));
                    }
                    break;
                case 2:
                    tempSize = CostumeSizeToAdd(menu);
                    temp = costume.FindAll(c => c.TypeOfCostume == "Superman");
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Costume("Superman", tempSize, 1));
                    }
                    break;
                case 3:
                    tempSize = CostumeSizeToAdd(menu);
                    temp = costume.FindAll(c => c.TypeOfCostume == "Spiderman");
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Costume("Spiderman", tempSize, 1));
                    }
                    break;
                case 4:
                    tempSize = CostumeSizeToAdd(menu);
                    temp = costume.FindAll(c => c.TypeOfCostume == "Vampire");
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Costume("Vampire", tempSize, 1));
                    }
                    break;
                case 5:
                    tempSize = CostumeSizeToAdd(menu);
                    temp = costume.FindAll(c => c.TypeOfCostume == "Witch");
                    controll = CheckIfCostumeSizeExist(temp, tempSize);
                    if (!controll)
                    {
                        costume.Add(new Costume("Witch", tempSize, 1));
                    }
                    break;
                case 6:
                    break;
            }
            SortAllCostumes(costume);
            SerializeCostumes(costume);
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
        public void SerializeCostumes(List<Costume> costume)
        {
            var jsonString = JsonConvert.SerializeObject(costume);
            string filePath = @"C:\Code Skola\Slutuppgift\Slutuppgift\Costume.json";
            if (File.Exists(filePath) == false)
            {
                File.WriteAllText(filePath, jsonString);
            }
            else
            {
                File.Delete(filePath);
                File.WriteAllText(filePath, jsonString);
            }
        }
        public void SerializeMembers(List<Member> members)
        {
            var jsonString = JsonConvert.SerializeObject(members);
            string filePath = @"C:\Code Skola\Slutuppgift\Slutuppgift\Member.json";
            if (File.Exists(filePath) == false)
            {
                File.WriteAllText(filePath, jsonString);
            }
            else
            {
                File.Delete(filePath);
                File.WriteAllText(filePath, jsonString);
            }
        }
        public void Exit(List<Costume> costume)
        {
            Console.WriteLine("\n\tAre you sure? If yes press ESCAPE, if no press any other key.");
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            if (pressedKey.Key == ConsoleKey.Escape)
            {
                SerializeCostumes(costume);
                Environment.Exit(0);
            }

        }
    }
}
