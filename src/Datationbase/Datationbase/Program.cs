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
            Table<Record> employees = new Table<Record>();
            employees.Add(Employee.New(1, "Jon Doe", 60000));       // INSERT INTO EMPLOYEE (ID, NAME, SALARY) VALUES (1, "Jon Doe", 60000);
            employees.Add(Employee.New(2, "Max Muster", 40000));   // INSERT INTO EMPLOYEE (ID, NAME, SALARY) VALUES (1, "Max Muster", 40000);
            employees.Add(Employee.New(3, "Marie Muster", 80000));
            log("Alle Mitarbeiter", employees);
            Predicate<Record> pred = (Record record) => (int)record["salary"] > 50000;  // SALARY > 50000
            Predicate<Record> pred2 = (Record record) => (int)record["salary"] < 70000; // SALARY < 70000
            List<Predicate<Record>> predicates = new List<Predicate<Record>>();
            predicates.Add(pred);
            predicates.Add(pred2);
            Table<Record> newEmployees = Actions.Select(employees, predicates); // SELECT * FROM Employee WHERE SALARY > 50000 AND SALARY < 70000
            log("Gefilterte Mitarbeiter", newEmployees);
            List<string> fieldsToDisplay = new List<string> { "id", "name" };
            Table<Record> projectedEmployees = Actions.Project(employees, fieldsToDisplay); // SELECT id, name FROM Employee
            log("Nur ID und name", projectedEmployees);
            Console.WriteLine("yeah2");
            Dictionary<string, string> keysToReplace = new Dictionary<string, string>() { ["name"] = "full name"};
            Table<Record> renamedEmployees = Actions.RenameColumns(employees, keysToReplace); // SELECT *, name AS "full name" as FROM Employee
            log("Full name statt name", renamedEmployees);
            Console.ReadLine();

        }

        static void log(string title, Table<Record> employees)
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
