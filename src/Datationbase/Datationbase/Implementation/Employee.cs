using Datationbase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Implementation
{
    class Employee: Record
    {

        public Employee(int id, string name, int salary)
        {
            Add("id", id);
            Add("name", name);
            Add("salary", salary);
        }
        public Employee(object[] ass)
        {
            Add("id", ass[0]);
            Add("name", ass[1]);
            Add("salary", ass[2]);
        }
        //public static Record New(int id, string name, int salary)
        //{
        //    Record record = new Record();
        //    record.Add("id", id);
        //    record.Add("name", name);
        //    record.Add("salary", salary);
        //    return record;
        //}
    }
}
// <Employee>
// <id>1</id>
// <name>Jon Doe</name>
// <salary>60000</salary
// </Employee>
