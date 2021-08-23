using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Database
{
    class Table<T> : HashSet<T> where T : Record
    {
        public Table() : base() { }
        public Table(HashSet<T> hashSet) : base(hashSet) { }
    }
}
