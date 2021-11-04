using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Menu
    {
        public CostumeRentalApp costumeRentalApp { get; set; } = new CostumeRentalApp();
        public MenuSetup menuSetup { get; set; } = new MenuSetup();
        public int SelectedIndex { get; set; }

        public void MainMenu(List<Costume> costume, Menu menu, User user)
        {
            ClearScreen();
            List<string> options = new List<string> { "Rent a costume", "Log in", "Admin", "Exit" };
            menuSetup = new MenuSetup("Costume rental", options);
            SelectedIndex = menuSetup.DisplaytInteractivMenu();
            switch (SelectedIndex)
            {
                case 0:
                    costumeRentalApp.RentACostume(costume, menu, user);
                    break;
                case 1:
                    MemberMenu(costume, user, menu);
                    break;
                case 2:
                    AdminMenu(costume, user, menu);
                    break;
                case 3:
                    costumeRentalApp.Exit(costume);
                    break;
            }
        }
        
        private void MemberMenu(List<Costume> costume, User user, Menu menu)
        {
            bool exit = true;
            while (exit)
            {
                ClearScreen();
                Console.CursorVisible = true;
                Console.WriteLine("\n\tLog in as member: ");
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
                        Start:
                        ClearScreen();
                        List<string> options = new List<string> { "Check rented costume", "Return costume", "Previously rented costumes", "Log out" };
                        menuSetup = new MenuSetup("Member", options);
                        SelectedIndex = menuSetup.DisplaytInteractivMenu();
                        switch (SelectedIndex)
                        {
                            case 0:
                                CheckInventoryMember(user.Members[i].RentedCostume);
                                goto Start;
                            case 1:
                                costumeRentalApp.ReturnACostume(costume, user.Members[i], menu);
                                goto Start;
                            case 2:
                                if(user.Members[i].PreviouslyRentedCostumes.Count == 0)
                                {
                                    Console.WriteLine("\n\tYou have not rented a costume before, press any key to go back");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    foreach (var c in user.Members[i].PreviouslyRentedCostumes)
                                    {
                                        Console.WriteLine($"\n\n\tType of costume: {c.TypeOfCostume}\n\tSize: {c.Size}");
                                    }
                                    Console.WriteLine("\n\n\tPress any key to go back");
                                    Console.ReadKey();
                                }
                                goto Start;
                            case 3:
                                exit = false;
                                break;
                        }
                        break;
                    }
                    else if((user.Members[i] is Member) && (inputUserName.ToUpper() != user.Members[i].UserName.ToUpper()
                            || inputPassword.ToUpper() != user.Members[i].Password.ToUpper()) && i == user.Members.Count - 1
                            || !(user.Members[i] is Member) && i == user.Members.Count - 1)
                    {
                        Console.WriteLine("\n\tInvalid username or Password, press ENTER to try again or press any other key to go back");
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.Enter)
                        {
                            continue;
                        }
                        else
                        {
                            exit = false;
                            break;
                        }
                    }
                }
            }
            string filePath = @"C:\Code Skola\Slutuppgift\Slutuppgift\Member.json";
            string jsonString = JsonConvert.SerializeObject(user.Members);
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
        private void AdminMenu(List<Costume> costume, User user, Menu menu)
        {
            while (true)
            {
                ClearScreen();
                Console.CursorVisible = true;
                Console.WriteLine("\n\tLog in as admin:");
                Console.Write("\n\tUsername: ");
                string inputUserName = Console.ReadLine();
                Console.Write("\n\tPassword: ");
                string inputPassword = Console.ReadLine();
                Console.CursorVisible = false;
                
                if ((user is Admin)
                        && inputUserName.ToUpper() == user.UserName.ToUpper()
                        && inputPassword.ToUpper() == user.Password.ToUpper())
                {
                    Start:
                    ClearScreen();
                    List<string> options = new List<string> { "Log a new costume in the system", "Check inventory", "Member list", "Log out"};
                    menuSetup = new MenuSetup("Admin", options);
                    SelectedIndex = menuSetup.DisplaytInteractivMenu();
                    switch (SelectedIndex)
                    {
                        case 0:
                            costumeRentalApp.CreateNewCostumeMenu(costume, menu);
                            goto Start;
                        case 1:
                            CheckInventory(costume);
                            Console.Clear();
                            goto Start;
                        case 2:
                            ClearScreen();
                            if(user.Members.Count == 0)
                            {
                                Console.WriteLine("\n\tNo members");
                            }
                            else
                            {
                                foreach (var member in user.Members)
                                {
                                    Console.WriteLine(member.ToString());
                                    Console.WriteLine();
                                }
                            }
                            Console.ReadKey();
                            goto Start;
                        case 3:
                            break;
                    }
                    break;
                }
                else if ((user is Admin) && (inputUserName.ToUpper() != user.UserName.ToUpper()
                        || inputPassword.ToUpper() != user.Password.ToUpper()) 
                        || !(user is Admin))
                {
                    Console.WriteLine("\n\tInvalid username or Password, press ENTER to try again or press any other key to go back");
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
        }
        private void CheckInventory(List<Costume> costume)
        {
            ClearScreen();
            foreach (var c in costume)
            {
                Console.WriteLine(c.ToString());
            }
            Console.ReadKey();
        }
        private void CheckInventoryMember(List<Costume> costume)
        {
            ClearScreen();
            if(costume.Count == 0)
            {
                Console.WriteLine("\n\n\tYou have no rented costumes");
            }
            else
            {
                foreach (var c in costume)
                {
                    Console.WriteLine($"\n\n\tType of costume: {c.TypeOfCostume}\n\tSize: {c.Size}");
                }
            }
            Console.WriteLine("\n\n\tPress any key to go back");
            Console.ReadKey();
        }
        
        public void ClearScreen()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(@"                                                                                           
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                            
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                              
                                                                                                                            ");
            Console.SetCursorPosition(0, 0);
        }
    }
}
