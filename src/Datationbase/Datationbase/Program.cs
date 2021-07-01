using Datationbase.Database;
using Datationbase.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase
{
    class Program
    {
        static void Main(string[] args)
        {
            Table<Employee> employees = new Table<Employee>();
            employees.Add(new Employee(1, "Jon Doe", 60000));       // INSERT INTO EMPLOYEE (ID, NAME, SALARY) VALUES (1, "Jon Doe", 60000);
            employees.Add(new Employee(2, "Max Muster", 40000));   // INSERT INTO EMPLOYEE (ID, NAME, SALARY) VALUES (1, "Jon Doe", 60000);
            employees.Add(new Employee(3, "Marie Muster", 80000));

            Predicate<Employee> pred = (Employee record) => (int)record["salary"] > 50000;  // SALARY > 50000
            Predicate<Employee> pred2 = (Employee record) => (int)record["salary"] < 70000; // SALARY < 70000
            List<Predicate<Employee>> adsd = new List<Predicate<Employee>>();
            adsd.Add(pred);
            adsd.Add(pred2);
            Table<Employee> newEmployees = Actions.Select(employees, adsd); // SELECT * FROM Employee WHERE SALARY > 50000 AND SALARY < 70000
            Console.WriteLine("yeah");

        }
    }
}
