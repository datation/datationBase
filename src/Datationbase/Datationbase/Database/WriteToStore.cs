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
            string filePath = @Config.path + typeof(T).Name + ".csv";

            foreach (Record record in table)
            {
                List<string> result = new List<string>();
                foreach (KeyValuePair<string, object> field in record)
                {
                    if (field.Value is string)
                    {
                        // Add quotes
                        result.Add("\"" + field.Value + "\"");
                    } else
                    {
                        // Save as is
                        result.Add(field.Value.ToString());
                    }
                }
                fileData += string.Join(",", result);
                fileData += "\n";
            }

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(fileData);
            }
        }
    }
}
