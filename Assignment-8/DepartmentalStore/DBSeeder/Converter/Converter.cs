using DepartmentalStore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSeeder.Converter
{
    public static class Converter
    {
        public static List<T> ConvertToEntity<T>(List<string> data, Func<string,T> MapperDelegate)
        {
            List<T> _data = new List<T>();
            data.ForEach(line => _data.Add(MapperDelegate(line)));
            return _data;
        }
        
    }
}
