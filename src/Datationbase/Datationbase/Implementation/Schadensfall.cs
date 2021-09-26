using Datationbase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Implementation
{
    class Schadensfall: Record
    {

        public Schadensfall(int id, string name, int amount)
        {
            Add("id", id);
            Add("name", name);
            Add("amount", amount);
        }
        public Schadensfall(object[] obj)
        {
            Add("id", obj[0]);
            Add("name", obj[1]);
            Add("amount", obj[2]);
        }
    }
}
