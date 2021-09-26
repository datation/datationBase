using Datationbase.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Datationbase
{
    public class XML
    {
        /**
         * This function reads the data form an XML file and converts it to a Table of the Records T.
         * The fields and the types of the fields must be the same as in the Record T
         * 
         * Example XML:
         * <Employees>
	     *   <Employee>
		 *       <ID type="int">1</ID>
		 *       <Name type="string">John</Name>
		 *       <Salary type="int">100</Salary>
	     *   </Employee>
	     *   <Employee>
		 *       <ID type="int">2</ID>
		 *       <Name type="string">Dave</Name>
		 *       <Salary type="int">5</Salary>
	     *    </Employee>
         * </Employees>

         **/
        public static Table<T> Read<T>(string pathToFile) where T : Record
        {
            try
            {
                XDocument doc = XDocument.Load(pathToFile);
                Table<T> allObj = new Table<T>();
                foreach (XElement el in doc.Root.Elements())
                {
                    Dictionary<string, object> record = new Dictionary<string, object>();
                    foreach (XElement child in el.Elements())
                    {
                        string fieldtype = child.Attribute("type").Value;
                        Type type = GetMappedType(fieldtype);
                        // Converts the child.Value (string) to another type (string, int, bool)
                        // in order to add the typed fields to the record.
                        var typedValue = Convert.ChangeType(child.Value, type);
                        record.Add(child.Name.LocalName, typedValue);
                    }
                    // use the generic dictionary record to create a typed Instance of T
                    T typedRecord = (T)Activator.CreateInstance(typeof(T), record);
                    allObj.Add(typedRecord);
                }
                return allObj;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File could not be parsed:");
                Console.WriteLine(e);
                Console.ReadLine();
            }
            return null;
        }

        /**
         * Gets the C# Type based on the type attribute of the XML Element
         **/
        private static Type GetMappedType(string typeName)
        {
            switch (typeName)
            {
                case "string":
                    return Type.GetType("System.String");
                case "int":
                    return Type.GetType("System.Int32");
                case "bool":
                    return Type.GetType("System.Boolean");
                default:
                    return null;

            }
        }
    }
}
