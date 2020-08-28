using HardwareLedger.DBObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public class Reserve : PgmRow
    {
        public int ReserveCode { get; set; }

        public int ItemTypeCode { get; set; }

        public string Name { get; set; }

        public int StateCode { get; set; }

        public DateTime InsertTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public static Dictionary<string, string> DBContrastDictionary
        {
            get
            {
                var dic = new Dictionary<string, string>();

                dic.Add(nameof(DBObject.Reserve.Name), nameof(Reserve.Name));
                dic.Add(nameof(DBObject.Reserve.StateCode), nameof(Reserve.StateCode));
                dic.Add(nameof(DBObject.Reserve.InsertTime), nameof(Reserve.InsertTime));
                dic.Add(nameof(DBObject.Reserve.UpdateTime), nameof(Reserve.UpdateTime));
                dic.Add(nameof(DBObject.Reserve.ReserveCode), nameof(Reserve.ReserveCode));
                dic.Add(nameof(DBObject.Reserve.ItemTypeCode), nameof(Reserve.ItemTypeCode));

                return dic;
            }
        }

        public static implicit operator DBObject.Reserve(Reserve res)
        {
            var row = new DBObject.Reserve();

            foreach (var kv in DBContrastDictionary)
                row[kv.Key] = res[kv.Value];

            return row;
        }

        public static implicit operator Reserve(DBObject.Reserve row)
        {
            var res = new Reserve();

            foreach (var kv in DBContrastDictionary)
                res[kv.Value] = row[kv.Key];

            return res;
        }

        public override bool Convertible<D>()
        {
            return new D().GetType() == typeof(DBObject.Reserve);
        }

        public override D Convert<D>()
        {
            if (Convertible<D>() == false)
                return default;

            var dd = new D();

            if (dd is DBObject.Reserve)
                return dd.ConvertDBData(this) as D;
            else
                return null;
        }

        public override PgmRow Convert<D>(D data)
        {
            if (Convertible<D>() == false)
                return default;

            var dd = new D();
            var row = new Reserve();

            foreach (var con in DBContrastDictionary)
            {
                row[con.Value] = data[con.Key];
            }

            return row;
        }
    }
}
