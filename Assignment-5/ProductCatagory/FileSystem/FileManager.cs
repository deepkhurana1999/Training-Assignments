using ICatalog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystem
{

    public  class FileManager
    {
        string filePath;
        
        public FileManager(string path)
        {
            filePath = path;
        }
        public List<string> GetAllData()
        {
            List<string> _products = new List<string>();
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while (!streamReader.EndOfStream)// && lineNumber<chunkSize)
                {
                    string line = streamReader.ReadLine();
                    _products.Add(line);
                }
            }
            return _products;
        }

        public void SaveData(string data)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(data);
            }
        }

        public void DeleteData(List<string> data)
        {
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                data.ForEach(line => writer.WriteLine(line));
            }
        }


        //Method to delete data without overriting the file
        //public static void DeleteData(int id)
        //{
        //    using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //    {
        //        int size = 0;
        //        int stringToBeReplacedSize = 0;
        //        using (StreamReader parentReader = new StreamReader(stream))
        //        {
        //            int lineNumber = 1;
        //            while (!parentReader.EndOfStream && id > 0 && id != lineNumber)
        //            {
        //                string line = parentReader.ReadLine();
        //                Console.WriteLine(line);
        //                size += line.Length;
        //                id--;
        //            }
        //            Console.WriteLine(parentReader.BaseStream.Position);
        //            stringToBeReplacedSize = (parentReader.ReadLine()).Length;
        //            parentReader.BaseStream.Seek(size + id, SeekOrigin.Begin);
        //            Console.WriteLine(parentReader.ReadLine());
        //        }
        //        using (FileStream writer = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //        {
        //                writer.Seek(size+4, SeekOrigin.Begin);
        //            byte[] @buffer = new byte[stringToBeReplacedSize];
        //            writer.Write(buffer);
        //        }
        //    }
        //}
    }
}
