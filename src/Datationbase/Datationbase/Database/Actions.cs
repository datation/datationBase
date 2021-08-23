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
        public static Table<T> Select<T>(Table<T> table, List<Predicate<T>> predicates) where T: Record
        {
            Table<T> filteredTable = new Table<T>(table);
            foreach (Predicate<T> predicate in predicates)
            {
                filteredTable.RemoveWhere((T record) => predicate(record) == false);
            }
            return filteredTable;
        }

        ///**
        // * The project operator allows the user to apply filters to the columns (i.e the removing of unnecessary information).
        // */
        //public static Table<T> Project<T>(Table<T> table, List<string> columns) where T : Record
        //{
        //    Table<T> newTable = new Table<T>();
        //    foreach (T record in table)
        //    {
        //        newTable.Add(record.filter(it => columns.Contains(it.Key)));
        //    }
        //    return newTable;
        //}

        //public static Table<T> RenameColumns<T>(Table<T> table, Dictionary<string, string> columnRenames) where T : Record
        //{
        //    Table<T> newTable = new Table<T>();
        //    foreach (T record in table)
        //    {
        //        newTable.Add(T.ReplaceKeys(record, columnRenames));
        //    }
        //    return newTable;
        //}
    }
}
