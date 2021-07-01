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
        public static HashSet<Record> Select(HashSet<Record> hashSet, List<Predicate<Record>> predicates)
        {
            var clonedSet = new HashSet<Record>(hashSet, hashSet.Comparer);
            foreach (Record record in clonedSet)
            {
                foreach (Predicate<Record> predicate in predicates)
                {
                    clonedSet.RemoveWhere(predicate);
                }
            }
            return clonedSet;
        }
    }
}
