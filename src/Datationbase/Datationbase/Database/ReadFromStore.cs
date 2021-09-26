using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Database
{
    class ReadFromStore
    {
        public static Table<T> Read<T>() where T : Record
        {
            string filePath = @Config.path + typeof(T).Name + ".csv";

            if(File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(@filePath))
                {
                    Table<T> returnValue = new Table<T>();
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');
                        List<object> result = new List<object>();
                        foreach (string value in values)
                        {
                            int number;
                            bool boo;
                            if (Int32.TryParse(value, out number))
                            {
                                result.Add(number);
                            } else if (Boolean.TryParse(value, out boo))
                            {
                                result.Add(boo);
                            } else
                            {
                                char[] charsToTrim = { '\\', '"' };
                                result.Add(value.Trim(charsToTrim));
                            }
                        }
                        var obj = (T)Activator.CreateInstance(typeof(T), result.ToArray());

                        returnValue.Add(obj);
                    }
                    return returnValue;
                }
            } else
            {
                throw new FileNotFoundException("The desired table could not be found");
            }
        }
    }
}
