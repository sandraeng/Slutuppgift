using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            List<string> options = new List<string> { "Rent a costume", "Return a costume", "Log in", "Admin", "Exit" };
            menuSetup = new MenuSetup("Costume rental", options);
            SelectedIndex = menuSetup.DisplaytInteractivMenu();
            switch (SelectedIndex)
            {
                case 0:
                    costumeRentalApp.RentACostume(costume, menu, user);
                    ClearScreen();
                    break;
                case 1:
                    ReturnACostume();
                    break;
                case 2:
                    MemberLogIn(costume, user);
                    break;
                case 3:
                    AdminMenu(costume, user);
                    ClearScreen();
                    break;
                case 4:
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
                Console.WriteLine("\n\tPassword: ");
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
                    else if((user.Users[i] is Member)
                        && inputUserName.ToUpper() != user.Users[i].UserName.ToUpper()
                        && inputPassword.ToUpper() != user.Users[i].Password.ToUpper() && i == user.Users.Count - 1)
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
        private void AdminMenu(List<Costume> costume, User user)
        {
            bool exit = true;
            while (exit)
            {
                ClearScreen();
                Console.CursorVisible = true;
                Console.Write("\n\tUsername: ");
                string inputUserName = Console.ReadLine();
                Console.WriteLine("\n\tPassword: ");
                string inputPassword = Console.ReadLine();
                Console.CursorVisible = false;
                for (int i = 0; i < user.Users.Count; i++)
                {
                    if ((user.Users[i] is Admin)
                            && inputUserName.ToUpper() == user.Users[i].UserName.ToUpper()
                            && inputPassword.ToUpper() == user.Users[i].Password.ToUpper())
                    {
                        ClearScreen();
                        List<string> options = new List<string> { "Log a new costume in the system", "Check inventory", "Log out"};
                        menuSetup = new MenuSetup("Admin", options);
                        SelectedIndex = menuSetup.DisplaytInteractivMenu();
                        switch (SelectedIndex)
                        {
                            case 0:
                                CreateNewCostumeMenu(costume);
                                continue;
                            case 1:
                                CheckInventory(costume);
                                continue;
                            case 2:
                                exit = false;
                                break;
                        }
                        break;
                    }
                    else if ((user.Users[i] is Admin)
                        && inputUserName.ToUpper() != user.Users[i].UserName.ToUpper()
                        && inputPassword.ToUpper() != user.Users[i].Password.ToUpper() || i == user.Users.Count - 1)
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
                Console.Write(c.ToString());
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
        public void CreateNewCostumeMenu(List<Costume> costume)
        {
            ClearScreen();
            List<string> options = new List<string> { "Fairy", "Devil", "Superman", "Spiderman", "Vampire", "Witch", "Go back" };
            menuSetup = new MenuSetup("Add a new costume to inventory, chose what costume you would like to add", options);
            SelectedIndex = menuSetup.DisplaytInteractivMenu();
            switch (SelectedIndex)
            {
                case 0:
                    Size tempSize = CostumeSizeToAdd();
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c] is Fairy)
                        {
                            if ((costume[c] as Fairy).Size == tempSize)
                            {
                                costume[c].NumberInStock++;
                                break;
                            }
                            else if ((costume[c] as Fairy).Size != tempSize && c == costume.Count - 1)
                            {
                                costume.Add(new Fairy("Fairy", tempSize, 1));
                                break;
                            }
                        }
                    }
                    break;
                case 1:
                    tempSize = CostumeSizeToAdd();
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c] is Devil)
                        {
                            if ((costume[c] as Devil).Size == tempSize)
                            {
                                costume[c].NumberInStock++;
                                break;
                            }
                            else if ((costume[c] as Devil).Size != tempSize && c == costume.Count - 1)
                            {
                                costume.Add(new Devil("Devil", tempSize, 1));
                                break;
                            }
                        }
                    }
                    break;
                case 2:
                    tempSize = CostumeSizeToAdd();
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
                        else if ((costume[c] as Superman).Size != tempSize && c == costume.Count - 1)
                        {
                            costume.Add(new Superman("Superman", tempSize, 1));
                            break;
                        }
                    }
                    break;
                case 3:
                    tempSize = CostumeSizeToAdd();
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c] is Spiderman)
                        {
                            if ((costume[c] as Spiderman).Size == tempSize)
                            {
                                costume[c].NumberInStock++;
                                break;
                            }
                            else if ((costume[c] as Spiderman).Size != tempSize && c == costume.Count - 1)
                            {
                                costume.Add(new Spiderman("Spiderman", tempSize, 1));
                                break;
                            }
                        }
                    }
                    break;
                case 4:
                    tempSize = CostumeSizeToAdd();
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c] is Vampire)
                        {
                            if ((costume[c] as Vampire).Size == tempSize)
                            {
                                costume[c].NumberInStock++;
                                break;
                            }
                            else if ((costume[c] as Vampire).Size != tempSize && c == costume.Count - 1)
                            {
                                costume.Add(new Vampire("Vampire", tempSize, 1));
                                break;
                            }
                        }
                    }
                    break;
                case 5:
                    tempSize = CostumeSizeToAdd();
                    for (int c = 0; c < costume.Count; c++)
                    {
                        if (costume[c] is Witch)
                        {
                            if ((costume[c] as Witch).Size == tempSize)
                            {
                                costume[c].NumberInStock++;
                                break;
                            }
                            else if ((costume[c] as Witch).Size != tempSize && c == costume.Count - 1)
                            {
                                costume.Add(new Witch("Witch", tempSize, 1));
                                break;
                            }
                        }
                    }
                    break;
                case 6:
                    break;
            }
        }
        public Size CostumeSizeToAdd()
        {
            ClearScreen();
            Size size = Size.S;
            List<string> options = new List<string> { "S", "M", "L", "XL", "XXL" };
            menuSetup = new MenuSetup("Chose what size the new costume has: ", options);
            SelectedIndex = menuSetup.DisplaytInteractivMenu();
            switch (SelectedIndex)
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
        public void ClearScreen()
        {
            Console.SetCursorPosition(1, 0);
            Console.WriteLine(@"                                                                                           
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                            
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                            
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              ");
            Console.SetCursorPosition(0, 0);
        }
    }
}
