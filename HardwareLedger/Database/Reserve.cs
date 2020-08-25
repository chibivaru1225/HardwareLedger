using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public class Reserve : IPgmDataRow
    {
        public int ReserveCode { get; set; }

        public int ItemTypeCode { get; set; }

        public string Name { get; set; }

        public ItemStateType State { get; set; }

        public string StateCode
        {
            get
            {
                return State.DBValue;
            }
            set
            {
                State = ItemStateType.GetTypeForDBValue(value);
            }
        }

        public DateTime InsertTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
