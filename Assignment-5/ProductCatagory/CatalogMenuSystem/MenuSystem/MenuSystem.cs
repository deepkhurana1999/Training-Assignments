using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogMenuSystem
{
    public class MenuSystem
    {
        private static Stack<Screen> menuTrace;
        private static MenuSystem menuSystemObj;
        private static string path = "";
        private static string oldPath = "";
        public static string Path { get { return path; } }
        private MenuSystem()
        {
            menuTrace = new Stack<Screen>();
        }
        public static MenuSystem GetInstance()
        {
            if(menuSystemObj == null)
            {
                menuSystemObj = new MenuSystem();
            }
            return menuSystemObj;
        }
        public void AddScreen(Screen screenNode)
        {
            if (path == "")
            {
                oldPath = "";
                path += screenNode.GetType().Name;
            }

            else
            {
                oldPath = path;
                path = path + " -> " + screenNode.GetType().Name;
            }
            menuTrace.Push(screenNode);
            Run();
            
        }

        private static void RemoveScreen()
        {
            path = oldPath;
            if(menuTrace.Count!=0)
            menuTrace.Pop();
        }
        private static void Run()
        {
            if(menuTrace.Count>0)
            {
                menuTrace.Peek().Run();
                RemoveScreen();
            }
            if (menuTrace.Count > 0)
                Run();
        }
    }
}
