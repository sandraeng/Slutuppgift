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

        public void MainMenu(Costume costume, Menu menu, Admin admin)
        {
            List<string> options = new List<string> { "Rent a costume", "Return a costume", "Log in", "Admin", "Exit" };
            menuSetup = new MenuSetup("Costume rental", options);
            SelectedIndex = menuSetup.DisplaytInteractivMenu();
            switch (SelectedIndex)
            {
                case 0:
                    costumeRentalApp.RentACostume(costume, menu);
                    ClearScreen();
                    break;
                case 1:
                    ReturnACostume();
                    break;
                case 2:
                    LogIn();
                    break;
                case 3:
                    AdminMenu(costume, admin);
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
        private void LogIn()
        {

        }
        private void AdminMenu(Costume costume, Admin admin)
        {
            ClearScreen();
            Console.CursorVisible = true;
            Console.Write("\n\tUsername: ");
            string inputUserName = Console.ReadLine();
            Console.Write("\n\tPassWord: ");
            string inputPassword = Console.ReadLine();
            Console.CursorVisible = false;
            if(inputUserName.ToUpper() == admin.UserName.ToUpper() && inputPassword.ToUpper() == admin.Password.ToUpper())
            {
                while (true)
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
                            ReturnACostume();
                            continue;
                        case 2:
                            LogIn();
                            break;
                    }
                    break;
                }
            }
            else
            {
                Console.WriteLine("\tIncorrect username or password");
            }
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
        public void CreateNewCostumeMenu(Costume costume)
        {
            ClearScreen();
            List<string> options = new List<string> { "Fairy", "Devil", "Superman", "Spiderman", "Vampire", "Witch" };
            menuSetup = new MenuSetup("Add a new costume to inventory, chose what costume you would like to add", options);
            SelectedIndex = menuSetup.DisplaytInteractivMenu();
            switch (SelectedIndex)
            {
                case 0:
                    foreach (var c in costume.Costumes)
                    {
                        if (c is Fairy)
                        {
                            
                            

                            
                        }
                    }
                    break;
                case 1:
                    foreach (var c in costume.Costumes)
                    {
                        if (c is Devil)
                        {
                            Console.WriteLine(c.ToString());
                        }
                    }
                    break;
                case 2:
                    foreach (var c in costume.Costumes)
                    {
                        if (c is Superman)
                        {
                            Console.WriteLine(c.ToString());
                        }
                    }
                    break;
                case 3:
                    foreach (var c in costume.Costumes)
                    {
                        if (c is Spiderman)
                        {
                            Console.WriteLine(c.ToString());
                        }
                    }
                    break;
                case 4:
                    foreach (var c in costume.Costumes)
                    {
                        if (c is Vampire)
                        {
                            Console.WriteLine(c.ToString());
                        }
                    }
                    break;
                case 5:
                    foreach (var c in costume.Costumes)
                    {
                        if (c is Witch)
                        {
                            Console.WriteLine(c.ToString());
                        }
                    }
                    break;
                case 6:
                    break;
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
