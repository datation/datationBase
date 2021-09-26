using Datationbase.Database;
using Datationbase.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datationbase
{
    class Program
    {
        static void Main(string[] args)
        {
            // insertData();
            insertDataXML();
            // read();
            // readFromNothing();
            // readWithPredicates();
            // updateData();
        }

        static void log<T>(string title, Table<T> schadensfaelle) where T: Record
        {
            Console.Write("\n" + title + "\n\n");
            foreach(Record record in schadensfaelle)
            {
                foreach(KeyValuePair<string,object> field in record)
                {
                    Console.Write(field.Key + ": " + field.Value + ", ");
                }
                Console.Write("\n");
            }
        }


        // Test Methods
        static void insertData()
        {
            // Preconditions

            // Test
            Table<Schadensfall> schadensfaelle = new Table<Schadensfall>();
            schadensfaelle.Add(new Schadensfall(1, "Jon Doe", 60000));       // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (1, "Jon Doe", 60000);
            schadensfaelle.Add(new Schadensfall(2, "Max Muster", 40000));    // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (2, "Max Muster", 40000);
            schadensfaelle.Add(new Schadensfall(3, "Marie Muster", 80000));  // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (3, "Marie Muster", 80000);
            WriteToStore.Write<Schadensfall>(schadensfaelle);
        }

        static void insertDataXML()
        {
            // Preconditions

            // Test
            Table<Schadensfall> schadensfaelle = XML.Read<Schadensfall>("PATH_TO_XML");
            WriteToStore.Write<Schadensfall>(schadensfaelle);
        }

        static void read()
        {
            // Preconditions
            Table<Schadensfall> schadensfaelle = new Table<Schadensfall>();
            schadensfaelle.Add(new Schadensfall(1, "Jon Doe", 60000));       // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (1, "Jon Doe", 60000);
            schadensfaelle.Add(new Schadensfall(2, "Max Muster", 40000));    // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (2, "Max Muster", 40000);
            schadensfaelle.Add(new Schadensfall(3, "Marie Muster", 80000));  // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (3, "Marie Muster", 80000);
            WriteToStore.Write<Schadensfall>(schadensfaelle);

            // Test
            Table<Schadensfall> readSchadensfaelle = ReadFromStore.Read<Schadensfall>();
            log("From file Mitarbeiter", readSchadensfaelle);
            Console.ReadLine();
        }

        static void readFromNothing()
        {
            // Preconditions
            
            // Test
            Table<Schadensfall> readSchadensfaelle = ReadFromStore.Read<Schadensfall>();
            log("From file Schadensfall", readSchadensfaelle);
            Console.ReadLine();
        }

        static void readWithPredicates()
        {
            // Preconditions
            Table<Schadensfall> schadensfaelle = new Table<Schadensfall>();
            schadensfaelle.Add(new Schadensfall(1, "Jon Doe", 60000));       // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (1, "Jon Doe", 60000);
            schadensfaelle.Add(new Schadensfall(2, "Max Muster", 40000));    // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (2, "Max Muster", 40000);
            schadensfaelle.Add(new Schadensfall(3, "Marie Muster", 80000));  // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (3, "Marie Muster", 80000);
            WriteToStore.Write<Schadensfall>(schadensfaelle);
            Table<Schadensfall> readSchadensfaelle = ReadFromStore.Read<Schadensfall>();

            // Test
            Predicate<Schadensfall> pred = (Schadensfall record) => (int)record["amount"] > 50000;  // AMOUNT > 50000
            Predicate<Schadensfall> pred2 = (Schadensfall record) => (int)record["amount"] < 70000; // AMOUNT < 70000
            List<Predicate<Schadensfall>> predicates = new List<Predicate<Schadensfall>>();
            predicates.Add(pred);
            predicates.Add(pred2);
            Table<Schadensfall> newSchadensfaelle = Actions.Select(readSchadensfaelle, predicates); // SELECT * FROM Schadensfall WHERE AMOUNT > 50000 AND AMOUNT < 70000
            log("From file Schadensfall", newSchadensfaelle);
            Console.ReadLine();
        }

        static void updateData()
        {
            // Preconditions
            Table<Schadensfall> schadensfaelle = new Table<Schadensfall>();
            schadensfaelle.Add(new Schadensfall(1, "Jon Doe", 60000));       // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (1, "Jon Doe", 60000);
            schadensfaelle.Add(new Schadensfall(2, "Max Muster", 40000));    // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (2, "Max Muster", 40000);
            schadensfaelle.Add(new Schadensfall(3, "Marie Muster", 80000));  // INSERT INTO SCHADENSFALL (ID, NAME, AMOUNT) VALUES (3, "Marie Muster", 80000);
            WriteToStore.Write<Schadensfall>(schadensfaelle);
            Table<Schadensfall> readSchadensfaelle = ReadFromStore.Read<Schadensfall>();

            // Test
            readSchadensfaelle.Remove(schadensfaelle.ElementAt(1));
            readSchadensfaelle.Add(new Schadensfall(1, "John Doe", 65000));
            WriteToStore.Write(schadensfaelle);
            log("From file Schadensfall", schadensfaelle);
            Console.ReadLine();
        }
    }
}
