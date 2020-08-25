using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger
{
    public class ItemType : IPgmDataRow
    {
        public int ItemTypeCode { get; set; }

        public String ItemTypeName { get; set; }
    }
}
