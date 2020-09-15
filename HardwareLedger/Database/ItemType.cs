using HardwareLedger.DBObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger
{
    public class ItemType : DBObject.ItemType, IPgmRow
    {
        public IPgmRow DownCastToIPgmRow(DBData data)
        {
            foreach (var column in data.Properties())
                this[column] = data[column];

            return this;
        }

        public bool PossibleDownCast<T>() where T : DBData, new()
        {
            var tt = new T();
            return tt is DBObject.ItemType;
        }

        public DBData UpCastToDBData()
        {
            var dbdata = new DBObject.ItemType();

            foreach (var column in dbdata.Properties())
                dbdata[column] = this[column];

            return dbdata;
        }
    }

    public interface ITypeCode
    {
        int TypeCode { get; set; }
    }
}
