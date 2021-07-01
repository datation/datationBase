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
            Table<Record> filteredTable = table;
            foreach (Predicate<Record> predicate in predicates)
            {
                filteredTable = filteredTable.filter(predicate);
            }
            return table;
        }

        /**
         * The project operator allows the user to apply filters to the columns (i.e the removing of unnecessary information).
         */
        public static Table<Record> Project(Table<Record> table, List<string> columns)
        {
            Table<Record> sddd = new Table<Record>();
            foreach (Record record in table)
            {
                sddd.Add(record.Filter(it => columns.Contains(it.Key)));
            }
            return sddd;
        }

    }
}
