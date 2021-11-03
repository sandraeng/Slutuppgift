using System;
using System.Collections.Generic;
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
                    Exit();
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
                for (int i = 0; i < user.Users.Count; i++)
                {
                    if ((user.Users[i] is Member) 
                        && inputUserName.ToUpper() == user.Users[i].UserName.ToUpper() 
                        && inputPassword.ToUpper() == user.Users[i].Password.ToUpper())
                    {
                        Start:
                        ClearScreen();
                        List<string> options = new List<string> { "Check rented costume", "Return costume", "Log out" };
                        menuSetup = new MenuSetup("Member", options);
                        SelectedIndex = menuSetup.DisplaytInteractivMenu();
                        switch (SelectedIndex)
                        {
                            case 0:
                                CheckInventoryMember((user.Users[i] as Member).RentedCostume);
                                goto Start;
                            case 1:
                                costumeRentalApp.ReturnACostume(costume, user.Users[i], menu);
                                goto Start;
                            case 2:
                                exit = false;
                                break;
                        }
                        break;
                    }
                    else if((user.Users[i] is Member) && (inputUserName.ToUpper() != user.Users[i].UserName.ToUpper()
                            || inputPassword.ToUpper() != user.Users[i].Password.ToUpper()) && i == user.Users.Count - 1
                            || !(user.Users[i] is Member) && i == user.Users.Count - 1)
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
        }
        private void AdminMenu(List<Costume> costume, User user, Menu menu)
        {
            bool exit = true;
            while (exit)
            {
                ClearScreen();
                Console.CursorVisible = true;
                Console.WriteLine("\n\tLog in as admin:");
                Console.Write("\n\tUsername: ");
                string inputUserName = Console.ReadLine();
                Console.Write("\n\tPassword: ");
                string inputPassword = Console.ReadLine();
                Console.CursorVisible = false;
                for (int i = 0; i < user.Users.Count; i++)
                {
                    if ((user.Users[i] is Admin)
                            && inputUserName.ToUpper() == user.Users[i].UserName.ToUpper()
                            && inputPassword.ToUpper() == user.Users[i].Password.ToUpper())
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
                                if(user.Users.Count == 1)
                                {
                                    Console.WriteLine("\n\tNo members");
                                }
                                else
                                {
                                    foreach (var member in user.Users)
                                    {
                                        if(member is Member)
                                        {
                                            Console.WriteLine(member.ToString());
                                            Console.WriteLine();
                                        }
                                    }
                                }
                                Console.ReadKey();
                                goto Start;
                            case 3:
                                exit = false;
                                break;
                        }
                        break;
                    }
                    else if ((user.Users[i] is Admin) && (inputUserName.ToUpper() != user.Users[i].UserName.ToUpper()
                            || inputPassword.ToUpper() != user.Users[i].Password.ToUpper()) && i == user.Users.Count - 1 
                            || !(user.Users[i] is Admin) && i == user.Users.Count - 1)
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
        private void Exit()
        {
            Console.WriteLine("\n\tAre you sure? If yes press ESCAPE, if no press any other key.");
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            if (pressedKey.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

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
