using Datationbase.Database;
using Datationbase.Implementation;
using System;
using System.Collections.Generic;

namespace Datationbase
{
    class Program
    {
        static void Main(string[] args)
        {
            Table<Employee> employees = new Table<Employee>();
            employees.Add(new Employee(1, "Jon Doe", 60000));       // INSERT INTO EMPLOYEE (ID, NAME, SALARY) VALUES (1, "Jon Doe", 60000);
            employees.Add(new Employee(2, "Max Muster", 40000));   // INSERT INTO EMPLOYEE (ID, NAME, SALARY) VALUES (1, "Max Muster", 40000);
            employees.Add(new Employee(3, "Marie Muster", 80000));
            log("Alle Mitarbeiter", employees);
            Predicate<Employee> pred = (Employee record) => (int)record["salary"] > 50000;  // SALARY > 50000
            Predicate<Employee> pred2 = (Employee record) => (int)record["salary"] < 70000; // SALARY < 70000
            List<Predicate<Employee>> predicates = new List<Predicate<Employee>>();
            predicates.Add(pred);
            predicates.Add(pred2);
            Table<Employee> newEmployees = Actions.Select(employees, predicates); // SELECT * FROM Employee WHERE SALARY > 50000 AND SALARY < 70000
            log("Gefilterte Mitarbeiter", newEmployees);
            //List<string> fieldsToDisplay = new List<string> { "id", "name" };
            //Table<Record> projectedEmployees = Actions.Project(employees, fieldsToDisplay); // SELECT id, name FROM Employee
            //log("Nur ID und name", projectedEmployees);
            //Console.WriteLine("yeah2");
            //Dictionary<string, string> keysToReplace = new Dictionary<string, string>() { ["name"] = "full name"};
            //Table<Record> renamedEmployees = Actions.RenameColumns(employees, keysToReplace); // SELECT *, name AS "full name" as FROM Employee
            //log("Full name statt name", renamedEmployees);
            Console.ReadLine();

            //Table<Person> _myTable = new Table<Person>();
            
            //Console.WriteLine(_myTable.GetType().GetGenericArguments()[0]);
            //_myTable.Add(new Person(1, "hans", 1000));
            //Console.ReadLine();

        }

        static void log<T>(string title, Table<T> employees) where T: Record
        {
            Console.Write("\n" + title + "\n\n");
            foreach(Record record in employees)
            {
                foreach(KeyValuePair<string,object> field in record)
                {
                    Console.Write(field.Key + ": " + field.Value + ", ");
                }
                Console.Write("\n");
            }
        }
    }
}
