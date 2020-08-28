using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger
{
    public class ItemType : PgmRow
    {
        public int ItemTypeCode { get; set; }

        public String ItemTypeName { get; set; }

        public static Dictionary<string, string> DBContrastDictionary
        {
            get
            {
                var dic = new Dictionary<string, string>();

                dic.Add(nameof(DBObject.ItemType.ItemTypeCode), nameof(ItemType.ItemTypeCode));
                dic.Add(nameof(DBObject.ItemType.ItemTypeName), nameof(ItemType.ItemTypeName));

                return dic;
            }
        }

        public static implicit operator DBObject.ItemType(ItemType res)
        {
            var row = new DBObject.ItemType();

            foreach (var kv in DBContrastDictionary)
                row[kv.Key] = res[kv.Value];

            return row;
        }

        public static implicit operator ItemType(DBObject.ItemType row)
        {
            var res = new ItemType();

            foreach (var kv in DBContrastDictionary)
                res[kv.Value] = row[kv.Key];

            return res;
        }

        public override bool Convertible<D>()
        {
            return new D().GetType() == typeof(DBObject.ItemType);
        }

        public override D Convert<D>()
        {
            if (Convertible<D>() == false)
                return default;

            var dd = new D();

            if (dd is DBObject.ItemType)
                return dd.ConvertDBData(this) as D;
            else
                return null;
        }

        public override PgmRow Convert<D>(D data)
        {
            if (Convertible<D>() == false)
                return default;

            var dd = new D();
            var row = new ItemType();

            foreach (var con in DBContrastDictionary)
            {
                row[con.Value] = data[con.Key];
            }

            return row;
        }
    }
}
