using HardwareLedger.DBObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger
{
    public class ReserveShipping : DBObject.ReserveShipping, IPgmRow, IStateCodeColumn, IShopCodeColumn
    {
        public int GetStateCode()
        {
            return this.State;
        }

        public int GetShopCode()
        {
            return this.ShopCode;
        }

        public IPgmRow DownCastToIPgmRow(DBData data)
        {
            foreach (var column in data.Properties())
                this[column] = data[column];

            return this;
        }

        public bool PossibleDownCast<T>() where T : DBData, new()
        {
            var tt = new T();
            return tt is DBObject.ReserveShipping;
        }

        public DBData UpCastToDBData()
        {
            var dbdata = new DBObject.ReserveShipping();

            foreach (var column in dbdata.Properties())
                dbdata[column] = this[column];

            return dbdata;
        }
    }
}
