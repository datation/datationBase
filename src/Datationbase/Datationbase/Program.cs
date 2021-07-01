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
            Table<Record> employees = new Table<Record>();
            employees.Add(Employee.New(1, "Jon Doe", 60000));       // INSERT INTO EMPLOYEE (ID, NAME, SALARY) VALUES (1, "Jon Doe", 60000);
            employees.Add(Employee.New(2, "Max Muster", 40000));   // INSERT INTO EMPLOYEE (ID, NAME, SALARY) VALUES (1, "Jon Doe", 60000);
            employees.Add(Employee.New(3, "Marie Muster", 80000));

            Predicate<Record> pred = (Record record) => (int)record["salary"] > 50000;  // SALARY > 50000
            Predicate<Record> pred2 = (Record record) => (int)record["salary"] < 70000; // SALARY < 70000
            List<Predicate<Record>> adsd = new List<Predicate<Record>>();
            adsd.Add(pred);
            adsd.Add(pred2);
            Table<Record> newEmployees = Actions.Select(employees, adsd); // SELECT * FROM Employee WHERE SALARY > 50000 AND SALARY < 70000
            Console.WriteLine("yeah");
            List<string> fieldsToDisplay = new List<string> { "id", "name" };
            Table<Record> projectedEmployees = Actions.Project(employees, fieldsToDisplay);
            Console.WriteLine("yeah2");

        }
    }
}
