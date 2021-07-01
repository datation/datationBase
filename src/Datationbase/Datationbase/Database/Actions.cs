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
        public static Table<T> Select<T>(Table<T> table, List<Predicate<T>> predicates) where T : Record
        {
            foreach (Predicate<T> predicate in predicates)
            {
                table.filter(predicate);
            }
            return table;
        }

        /**
         * The project operator allows the user to apply filters to the columns (i.e the removing of unnecessary information).
         */
        public static Table<Record> Project(Table<Record> table, List<string> columns)
        {
            //foreach (Record record in table)
            //{
            //    Record newRecoord = new Record();
            //    columns.ForEach((string column) => {
            //        newRecoord.Add(column, record[column]);
            //    });
            //    record = newRecoord;
            //});
            return table;
        }

    }
}
