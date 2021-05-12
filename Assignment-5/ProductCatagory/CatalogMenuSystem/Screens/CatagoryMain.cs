using System;
using CatalogManager;
using System.Collections.Generic;
using System.Text;

namespace CatalogMenuSystem
{
    public class CatagoryMain : Screen
    {
        private static MenuSystem menuSystem;
        public CatagoryMain()
        {
            menuSystem = MenuSystem.GetInstance();
            noOfPaths = 5;
        }
        public override void Run()
        {
            Console.Clear();
            CatagoryManager catagoryManager = CatagoryManager.getInstance();
            Console.WriteLine(MenuSystem.Path);
            Console.WriteLine("1. Enter a catagory\n2. List all catagories\n3. Delete a catagory\n4. Search a catagory\n5. Return to previous menu");


            Console.WriteLine("Enter the choice: ");
            do
            {
                Int32.TryParse("" + Console.ReadKey(false).KeyChar, out choice);
                switch (choice)
                {
                    case 1: menuSystem.AddScreen(new AddCatagoryMenu()); break;
                    case 2: menuSystem.AddScreen(new ListAllMenu()); break;
                    case 3: menuSystem.AddScreen(new DeleteCatagoryMenu()); break;
                    case 4: menuSystem.AddScreen(new SearchCatagoryMenu()); break;
                    case 5: return;
                    default: break;
                }
            } while (choice != noOfPaths);
        }

    }

    class AddCatagoryMenu : Screen
    {
        public override void Run()
        {
            Console.Clear();
            Console.WriteLine(MenuSystem.Path);

            CatagoryManager catagoryManager = CatagoryManager.getInstance();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            name.IsMandatory(ref name);
            Console.Write("Short Code: ");
            string shortCode = Console.ReadLine();
            shortCode.IsMandatory(ref shortCode);
            while (shortCode.Length > 4)
            {
                Console.WriteLine("ShortCode length must be smaller than 4. Please enter shortcode again.");
                shortCode = Console.ReadLine();
            }
            while (CatagoryManager.shortCodeSet.Contains(shortCode))
            {
                Console.WriteLine("ShortCode must be unique and it's length must be smaller than 4. Please enter shortcode again.");
                shortCode = Console.ReadLine();
            }
            CatagoryManager.shortCodeSet.Add(shortCode);
            Console.Write("Description: ");
            string desc = Console.ReadLine();
            desc.IsMandatory(ref desc);
            catagoryManager.AddCatagory(name, shortCode, desc);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    class ListAllMenu : Screen
    {
        public override void Run()
        {
            Console.Clear();
            Console.WriteLine(MenuSystem.Path);

            CatagoryManager catagoryManager = CatagoryManager.getInstance();
            catagoryManager.PrintAllCatagories();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    class SearchCatagoryMenu : Screen
    {
        public SearchCatagoryMenu()
        {
            noOfPaths = 3;
        }
        public override void Run()
        {
            Console.Clear();
            Console.WriteLine(MenuSystem.Path);

            CatagoryManager catagoryManager = CatagoryManager.getInstance();
            Console.WriteLine("Search by:\n1. ID\n2. Name\n3. Search Code");
            Int32.TryParse("" + Console.ReadKey(true).KeyChar, out choice);

            switch (choice)
            {
                case 1:
                    int id = -1; Console.Write("ID: ");
                    Int32.TryParse("" + Console.ReadKey(false).KeyChar, out id);
                    Console.WriteLine(); var listFound = catagoryManager.SearchCatagory(x => x.ID == id);
                    Console.WriteLine(catagoryManager.ToString(ref listFound)); break;
                case 2:
                    string name = ""; Console.Write("Name: ");
                    name = Console.ReadLine();
                    listFound =  catagoryManager.SearchCatagory(x => x.Name.ToLower().Equals(name.ToLower()) || x.Name.ToLower().Contains(name.ToLower()));
                    Console.WriteLine(catagoryManager.ToString(ref listFound)); break;
                case 3:
                    string shortCode = ""; Console.Write("Short Code: ");
                    shortCode = Console.ReadLine();
                    listFound = catagoryManager.SearchCatagory(x => x.ShortCode.ToLower().Equals(shortCode.ToLower()));
                    Console.WriteLine(catagoryManager.ToString(ref listFound)); break;
                default:
                    break;
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    class DeleteCatagoryMenu : Screen
    {
        public DeleteCatagoryMenu()
        {
            noOfPaths = 2;
        }
        public override void Run()
        {
            Console.Clear();
            Console.WriteLine(MenuSystem.Path);

            CatagoryManager catagoryManager = CatagoryManager.getInstance();
            Console.WriteLine("Delete by:\n1.ID\n2.Short Code");
            Int32.TryParse("" + Console.ReadKey(true).KeyChar, out choice);

            switch (choice)
            {
                case 1:
                    int id = -1; Console.Write("ID: ");
                    Int32.TryParse("" + Console.ReadKey(false).KeyChar, out id);
                    catagoryManager.DeleteCatagory(x => x.ID == id); break;
                case 2:
                    string shortCode = ""; Console.Write("Short Code: ");
                    shortCode = Console.ReadLine();
                    catagoryManager.DeleteCatagory(x => x.ShortCode.ToLower().Equals(shortCode.ToLower())); break;
                default:
                    break;
            }
            Console.WriteLine();

        }
    }
}
