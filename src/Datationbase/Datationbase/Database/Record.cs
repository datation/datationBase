using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Database
{
    /**
     * This class represents a Record (a row) in the database.
     * To create an own table extend this class and set the fields in the Constructor. 
     * 
     * Example: 
     * class Employee : Record
     * {
     *   public Employee(int id, string name, int salary)
     *   {
     *       Add("id", id);
     *       Add("name", name);
     *       Add("salary", salary);
     *   }
     * }
     */
    class Record : Dictionary<string, object> {
        public Record(): base() { }
        public Record(IDictionary<string, object> dictionary) : base(dictionary) { }

        public Record Filter(Predicate<KeyValuePair<string, object>> pred)
        {
            return new Record(this.Where(it => pred(it)).ToDictionary(i => i.Key, i => i.Value));
        }
    }
}
