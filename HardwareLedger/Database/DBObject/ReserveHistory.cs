using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    [Table("ReserveHistory")]
    public class ReserveHistory : DBData
    {
        public override string GetKeyColumnName() => throw new NotImplementedException();

        public override IEnumerable<string> Properties()
        {
            throw new NotImplementedException();
        }
    }
}
