using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public class ItemState : PgmRow
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

        public static Dictionary<string, string> DBContrastDictionary
        {
            get
            {
                var dic = new Dictionary<string, string>();

                dic.Add(nameof(DBObject.ItemState.StateCode), nameof(ItemState.StateCode));
                dic.Add(nameof(DBObject.ItemState.ApplyKbn), nameof(ItemState.ApplyKbnStr));
                dic.Add(nameof(DBObject.ItemState.StateName), nameof(ItemState.StateName));
                dic.Add(nameof(DBObject.ItemState.StateColor), nameof(ItemState.StateColorCode));

                return dic;
            }
        }

        public static implicit operator DBObject.ItemState(ItemState res)
        {
            var row = new DBObject.ItemState();

            foreach (var kv in DBContrastDictionary)
                row[kv.Key] = res[kv.Value];

            return row;
        }

        public static implicit operator ItemState(DBObject.ItemState row)
        {
            var res = new ItemState();

            foreach (var kv in DBContrastDictionary)
                res[kv.Value] = row[kv.Key];

            return res;
        }

        public override D Convert<D>()
        {
            if (Convertible<D>() == false)
                return default;

            var dd = new D();

            if (dd is DBObject.ItemState)
                return dd.ConvertDBData(this) as D;
            else
                return null;
        }

        public override PgmRow Convert<D>(D data)
        {
            if (Convertible<D>() == false)
                return default;

            var dd = new D();
            var row = new ItemState();

            foreach(var con in DBContrastDictionary)
            {
                row[con.Value] = data[con.Key];
            }

            return row;
        }

        public override bool Convertible<D>()
        {
            return new D().GetType() == typeof(DBObject.ItemState);
        }
    }
}
