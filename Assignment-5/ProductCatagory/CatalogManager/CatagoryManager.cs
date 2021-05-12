using ICatalog;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FileSystem.Converter;

namespace CatalogManager
{
    public class CatagoryManager
    {
        private static int idItr = 1;
        private static List<Catagory> _catagories;
        private static CatagoryManager catagoryManagerObj;
        public static HashSet<string> shortCodeSet;
        static FileSystem.FileManager fileManager;

        private CatagoryManager(){
            shortCodeSet = new HashSet<string>();
            fileManager = new FileSystem.FileManager(@"C:\Users\Admin\source\repos\ProductCatagory\ProductCatagory\Data\Catagory.csv");
            _catagories = CatagoryConverter.ConvertToCatagories(fileManager.GetAllData());
            _catagories.ForEach(x => shortCodeSet.Add(x.ShortCode));
            //_catagories.Add(new Catagory(idItr++, "Cat-1", "1", "abc"));
            //_catagories.Add(new Catagory(idItr++, "Cat-2", "2", "abc"));
            //_catagories.Add(new Catagory(idItr++, "Cat-3", "3", "abc"));
            //_catagories.Add(new Catagory(idItr++, "Cat-4", "4", "abc"));

            //shortCodeSet.Add("Cat-1");
            //shortCodeSet.Add("Cat-2");
            //shortCodeSet.Add("Cat-3");
            //shortCodeSet.Add("Cat-4");
        }

        public static List<Catagory> Catagories
        {
            get { return _catagories; }
        }

        public void PrintAllCatagories()
        {
            try
            {
                if (_catagories.Count <= 0)
                    throw new Exception("List is empty.");
                Console.WriteLine("Name\tShort Code\tDescription");
                _catagories.ForEach(x => Console.WriteLine($"{x.Name}\t\t{x.ShortCode}\t\t{x.Description}"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddCatagory(string name, string shortCode, string desc)
        {
            Catagory catagory = (new Catagory(idItr++, name, shortCode, desc));
            _catagories.Add(catagory);
            fileManager.SaveData(CatagoryConverter.ConvertToString(catagory));
        }
        public void DeleteCatagory(Predicate<Catagory> query)
        {
            int numberOfElementsRemoved = _catagories.RemoveAll(query);
            if (numberOfElementsRemoved > 0)
                fileManager.DeleteData(CatagoryConverter.ConvertToString(_catagories));
        }

        public List<Catagory> SearchCatagory(Predicate<Catagory> query)
        {
            var listFound = _catagories.FindAll(query);
            return listFound;
        }

        public static CatagoryManager getInstance()
        {
            if(catagoryManagerObj == null)
            {
                catagoryManagerObj = new CatagoryManager();
            }
            return catagoryManagerObj;
        }
        public string ToString(ref List<Catagory> catagories)
        {
            string result = "Name\tShort Code\tDescription\n";
            catagories.ForEach(x => result = result +($"{x.Name}\t\t{x.ShortCode}\t\t{x.Description}\n"));
            return result;
        }
    }
}
