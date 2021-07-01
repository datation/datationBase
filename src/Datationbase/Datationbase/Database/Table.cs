using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Database
{
    class Table<T> : HashSet<T> where T : Record
    {
        /**
         * filters the Table by the given predicate
         */
        public void filter(Predicate<T> pred)
        {
            RemoveWhere((T record) => pred(record) == false);
        }
    }
}
