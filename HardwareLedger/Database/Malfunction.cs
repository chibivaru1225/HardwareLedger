using HardwareLedger.DBObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public class Malfunction : DBObject.Malfunction, IPgmRow, ITypeCode, IStateCode, IShopCode
    {
        public int StateCode
        {
            get
            {
                return this.ItemStateCode;
            }
            set
            {
                this.ItemStateCode = value;
            }
        }


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

        public int TypeCode
        {
            get
            {
                return this.ItemTypeCode;
            }
            set
            {
                this.TypeCode = value;
            }
        }

        public String InsertTimeStr => InsertTime.ToString("yyyy/MM/dd HH:mm:ss");

        public String UpdateTimeStr => UpdateTime.ToString("yyyy/MM/dd HH:mm:ss");

        public IPgmRow DownCastToIPgmRow(DBData data)
        {
            foreach (var column in data.Properties())
                this[column] = data[column];

            return this;
        }

        public bool PossibleDownCast<T>() where T : DBData, new()
        {
            var tt = new T();
            return tt is DBObject.Malfunction;
        }

        public DBData UpCastToDBData()
        {
            var dbdata = new DBObject.Malfunction();

            foreach (var column in dbdata.Properties())
                dbdata[column] = this[column];

            return dbdata;
        }
    }

    public interface IMalfunctionCode
    {
        int MalfunctionCode { get; set; }
    }
}
