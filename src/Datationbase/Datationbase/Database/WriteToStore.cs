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

            foreach (Record record in table)
            {
                foreach (KeyValuePair<string, object> field in record)
                {
                    if (field.Value is string)
                    {
                        // Add quotes
                        fileData += "\"" + field.Value + "\"" + ",";
                    } else
                    {
                        // Save as is
                        fileData += field.Value + ",";
                    }
                }
                fileData += "\n";
            }

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.Write(fileData);
            }
        }
    }
}
