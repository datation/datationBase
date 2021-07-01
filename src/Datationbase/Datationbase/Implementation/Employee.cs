﻿using Datationbase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Implementation
{
    class Employee : Record
    {
        public Employee(int id, string name, int salary)
        {
            Add("id", id);
            Add("name", name);
            Add("salary", salary);
        }
    }
}
// <Employee>
// <id>1</id>
// <name>Jon Doe</name>
// <salary>60000</salary
// </Employee>
