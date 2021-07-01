using Datationbase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Implementation
{
    static class Employee
    {
        public static Record New(int id, string name, int salary)
        {
            Record record = new Record ();
            record.Add("id", id);
            record.Add("name", name);
            record.Add("salary", salary);
            return record;
        }
    }
}
// <Employee>
// <id>1</id>
// <name>Jon Doe</name>
// <salary>60000</salary
// </Employee>
