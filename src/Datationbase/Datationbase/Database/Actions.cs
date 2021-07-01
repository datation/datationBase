using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Database
{
    class Actions
    {
        /**
         * This function will take a list of Records and return only the Records that meet all given predicates.
         **/
        public static List<Record> Select(List<Record> table, List<Predicate<Record>> predicates)
        {
            List<Record> filteredList = table;
            foreach (Predicate<Record> predicate in predicates)
            {
                filteredList = filteredList.FindAll(predicate);
            }
            return filteredList;
        }

    }
}
