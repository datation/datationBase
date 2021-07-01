using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datationbase.Database
{
    class Record
    {
        Dictionary<string, object> data;
        public Record(Dictionary<string, object> data)
        {
            this.data = data; ;
        }
    }
}
