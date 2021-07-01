using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Database
{
    static class Actions
    {
        /**
         * The select operator is used to select records in our table.
         * This function will take a list of Records and return only the Records that meet all given predicates.
         */
        public static Table<Record> Select(Table<Record> table, List<Predicate<Record>> predicates)
        {
            Table<Record> filteredTable = new Table<Record>(table);
            foreach (Predicate<Record> predicate in predicates)
            {
                filteredTable.RemoveWhere((Record record) => predicate(record) == false);
            }
            return filteredTable;
        }

        /**
         * The project operator allows the user to apply filters to the columns (i.e the removing of unnecessary information).
         */
        public static Table<Record> Project(Table<Record> table, List<string> columns)
        {
            Table<Record> newTable = new Table<Record>();
            foreach (Record record in table)
            {
                newTable.Add(Record.Filter(record, it => columns.Contains(it.Key)));
            }
            return newTable;
        }

        public static Table<Record> RenameColumns(Table<Record> table, Dictionary<string, string> columnRenames)
        {
            Table<Record> newTable = new Table<Record>();
            foreach (Record record in table)
            {
                newTable.Add(Record.ReplaceKeys(record, columnRenames));
            }
            return newTable;
        }
    }
}
