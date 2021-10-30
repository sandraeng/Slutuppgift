using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Menu
    {
        public MenuSetup menuSetup { get; set; } = new MenuSetup();
        public int SelectedIndex { get; set; }

        public void MainMenu(Costume costume)
        {
            List<string> options = new List<string> { "Rent a costume", "Return a costume", "Log in", "Admin", "Exit" };
            menuSetup = new MenuSetup("Costume rental", options);
            SelectedIndex = menuSetup.DisplaytInteractivMenu();
            switch (SelectedIndex)
            {
                case 0:
                    RentACostume(costume);
                    ClearScreen();
                    break;
                case 1:
                    ReturnACostume();
                    break;
                case 2:
                    LogIn();
                    break;
                case 3:
                    Admin();
                    break;
                case 4:
                    //Exit();
                    break;
            }
        }
        private void RentACostume(Costume costume)
        {
            while (true)
            {
                ClearScreen();
                List<string> options = new List<string> { "Fairy", "Devil", "Superman", "Spiderman", "Vampire", "Witch", "Go Back" };
                menuSetup = new MenuSetup("Rent a costume, chose what costume you would like to rent", options);
                SelectedIndex = menuSetup.DisplaytInteractivMenu();
                ClearScreen();
                switch (SelectedIndex)
                {
                    case 0:
                        options.Clear();
                        foreach(var c in costume.Costumes)
                        {
                            if(c is Fairy)
                            {
                                options.Add(c.ToString());
                            }
                        }
                        menuSetup = new MenuSetup("Rent a costume, chose what size you would like", options);
                        SelectedIndex = menuSetup.DisplaytInteractivMenu();
                        continue;
                    case 1:
                        options.Clear();
                        foreach (var c in costume.Costumes)
                        {
                            if (c is Devil)
                            {
                                options.Add(c.ToString());
                            }
                        }
                        menuSetup = new MenuSetup("Rent a costume, chose what size you would like", options);
                        SelectedIndex = menuSetup.DisplaytInteractivMenu();
                        continue;
                    case 2:
                        options.Clear();
                        foreach (var c in costume.Costumes)
                        {
                            if (c is Superman)
                            {
                                options.Add(c.ToString());

                            }
                        }
                        menuSetup = new MenuSetup("Rent a costume, chose what size you would like", options);
                        SelectedIndex = menuSetup.DisplaytInteractivMenu();
                        continue;
                    case 3:
                        options.Clear();
                        foreach (var c in costume.Costumes)
                        {
                            if (c is Spiderman)
                            {
                                options.Add(c.ToString());

                            }
                        }
                        menuSetup = new MenuSetup("Rent a costume, chose what size you would like", options);
                        SelectedIndex = menuSetup.DisplaytInteractivMenu();
                        continue;
                    case 4:
                        options.Clear();
                        foreach (var c in costume.Costumes)
                        {
                            if (c is Vampire)
                            {
                                options.Add(c.ToString());

                            }
                        }
                        menuSetup = new MenuSetup("Rent a costume, chose what size you would like", options);
                        SelectedIndex = menuSetup.DisplaytInteractivMenu();
                        continue;
                    case 5:
                        options.Clear();
                        foreach (var c in costume.Costumes)
                        {
                            if (c is Witch)
                            {
                                options.Add(c.ToString());

                            }
                        }
                        menuSetup = new MenuSetup("Rent a costume, chose what size you would like", options);
                        SelectedIndex = menuSetup.DisplaytInteractivMenu();
                        continue;
                    case 6:

                        break;
                }
                break;
            }

        }
        private void ReturnACostume()
        {

        }
        private void LogIn()
        {

        }
        private void Admin()
        {

        }
        public void RentalMenu()
        {
            
            
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
        public void MembersMenu()
        {
            string[] menuOptions = { "Order history", "Rented costume", "Log out" };
            foreach (var option in menuOptions)
            {
                Console.WriteLine(option);
            }
        }
        public void ReturnMenu()
        {
            string[] menuOptions = { "Rent a costume", "Return a costume", "Log in", "Admin" };
            foreach (var option in menuOptions)
            {
                Console.WriteLine(option);
            }
        }
        private void ClearScreen()
        {
            Console.SetCursorPosition(1, 0);
            Console.WriteLine(@"                                                                                           
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                            
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            
                                                                                                                               
                                                                                                                              
                                                                                                                            
                                                                                                                              
                                                                                                                              
                                                                                                                            ");
        }
    }
}
