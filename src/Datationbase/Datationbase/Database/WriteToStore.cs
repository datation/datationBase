using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Database
{
    class WriteToStore
    {
        public static void Write<T>(Table<T> table) where T: Record
        {
            string fileData = "";
            string filePath = @Config.path + typeof(T).Name + ".txt";

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            } else
            {
                fileData = File.ReadAllText(filePath);
            }

            fileData += string.Join("", table);

            File.WriteAllText(filePath, fileData, Encoding.UTF8);


            Console.WriteLine(fileData);
            Console.ReadLine();
        }
    }
}
