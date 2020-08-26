using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public class ItemState
    {
        public int StateCode { get; set; }

        public ApplyKbn ApplyKbn { get; set; }

        public int ApplyKbnStr 
        { 
            get
            {
                return ApplyKbn.DBValue;
            }
            set
            {
                ApplyKbn = ApplyKbn.GetKbnForDBValue(value);
            }
        }

        public string StateName { get; set; }

        public int StateColorCode { get; set; }

        public Color StateColor
        {
            get
            {
                return Color.FromArgb(StateColorCode);
            }
            set
            {
                StateColorCode = value.ToArgb();
            }
        }
    }
}
