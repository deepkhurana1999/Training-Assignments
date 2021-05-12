using ICatalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Converter
{
    public static class CatagoryConverter
    {
        public static List<Catagory> ConvertToCatagories(List<string> data)
        {
            List<Catagory> _Catagories = new List<Catagory>();
            data.ForEach(line => _Catagories.Add(Mapper.Mapper.CatagoryMapper(line)));
            return _Catagories;
        }
        public static List<string> ConvertToString(List<Catagory> data)
        {
            List<string> _Catagories = new List<string>();
            data.ForEach(line => _Catagories.Add(ConvertToString(line)));
            return _Catagories;
        }

        public static string ConvertToString(Catagory catagory)
        {
            return ($"{catagory.ID},{catagory.Name},{catagory.ShortCode},{catagory.Description}");
        }
    }
}
