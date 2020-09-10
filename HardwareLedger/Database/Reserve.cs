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
    public class Reserve : DBObject.Reserve, IPgmRow, IStateCodeColumn, ITypeCodeColumn
    {
        public ZaikoType Zaiko
        {
            get
            {
                return ZaikoType.GetTypeForDBValue(ZaikoKbn);
            }
            set
            {
                this.ZaikoKbn = ZaikoType.GetDBValue(value);
            }
        }

        public String InsertTimeStr => InsertTime.ToString("yyyy/MM/dd HH:mm:ss");

        public String UpdateTimeStr => UpdateTime.ToString("yyyy/MM/dd HH:mm:ss");


        public int GetStateCode()
        {
            return ItemStateCode;
        }

        public int GetTypeCode()
        {
            return ItemTypeCode;
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
            return tt is DBObject.Reserve;
        }

        public DBData UpCastToDBData()
        {
            var dbdata = new DBObject.Reserve();

            foreach(var column in dbdata.Properties())
                dbdata[column] = this[column];

            return dbdata;
        }
    }
}
