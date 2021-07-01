using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Database
{
    class Table<Record> : HashSet<Record>
    {
        /**
         * filters the Table by the given predicate
         */
        public Table<Record> filter(Predicate<Record> pred)
        {
            RemoveWhere((Record record) => pred(record) == false);
            return this;
        }
    }
}
