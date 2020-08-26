using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.JSONObject
{
    public class ItemState
    {
        public int StateCode { get; set; }

        public int ApplyKbn { get; set; }

        public string StateName { get; set; }

        public int StateColor { get; set; }
    }
}
