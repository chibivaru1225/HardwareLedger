using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    public class Malfunction : DBData
    {
        public override DBData ConvertDBData<T>(T pgmrow)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> Properties()
        {
            throw new NotImplementedException();
        }
    }
}
