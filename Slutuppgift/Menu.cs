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
                    ClearScreen();
                    break;
                case 1:
                    MemberLogIn(costume, user);
                    break;
                case 2:
                    AdminMenu(costume, user, menu);
                    ClearScreen();
                    break;
                case 3:
                    Exit();
                    break;
            }
        }
        private void ReturnACostume()
        {

        }
        private void MemberLogIn(List<Costume> costume, User user)
        {
            bool exit = true;
            while (exit)
            {
                ClearScreen();
                Console.CursorVisible = true;
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
                        ClearScreen();
                        List<string> options = new List<string> { "Check rented costume", "Return costume", "Log out" };
                        menuSetup = new MenuSetup("Member", options);
                        SelectedIndex = menuSetup.DisplaytInteractivMenu();
                        switch (SelectedIndex)
                        {
                            case 0:
                                continue;
                            case 1:
                                continue;
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
                        List<string> options = new List<string> { "Log a new costume in the system", "Check inventory", "Log out"};
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
                                exit = false;
                                break;
                        }
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
            Console.SetCursorPosition(1, 0);
            Console.WriteLine(@"                                                                                           
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                            
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                              
                                                                                                                            ");
            Console.SetCursorPosition(0, 0);
        }
    }
}
