using System;
using CatalogManager;
using CatalogMenuSystem;

namespace ProductCatagory
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuSystem menuSystem = MenuSystem.GetInstance();
            menuSystem.AddScreen(new MainScreen());

        }
        
        
    }
}
