using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace DBSeeder
{
    //Not Used and more mapper needed for serialization
    class FileManager
    {
        string filePath;
        public FileManager(string path)
        {
            filePath = path;
        }
        public List<string> GetAllData()
        {
            List<string> _data = new List<string>();
            using(StreamReader reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();
                _data.Add(line);
            }
            return _data;
        }
    }
}
