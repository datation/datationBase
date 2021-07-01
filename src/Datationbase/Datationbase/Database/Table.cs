using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Database
{
    class Table<Record> : HashSet<Record>
    {
        public Table() : base() { }
        public Table(HashSet<Record> hashSet) : base(hashSet) { }
    }
}
