using CatalogManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogMenuSystem
{
    public class MainScreen: Screen
    {
        private static MenuSystem menuSystem;

        public MainScreen()
        {
            menuSystem = MenuSystem.GetInstance();
            noOfPaths = 3;
        }
        public override void Run()
        {
            Console.Clear();
            Console.WriteLine(MenuSystem.Path);
            CatagoryManager catagoryManager = CatagoryManager.getInstance();
            Console.WriteLine("Search by:\n1. Catagory\n2. Product\n3. Exit the App!!");
            Int32.TryParse("" + Console.ReadKey(true).KeyChar, out choice);

            switch (choice)
            {
                case 1: menuSystem.AddScreen(new CatagoryMain()); break;
                case 2: menuSystem.AddScreen(new ProductMain()); break;
                case 3: return;
                default:
                    break;
            }
            Console.WriteLine();

        }
    }
}
