using HardwareLedger.DBObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger
{
    public class Malfunction : DBObject.Malfunction, IPgmRow, ITypeCodeColumn
    {
        public String InsertTimeStr => InsertTime.ToString("yyyy/MM/dd HH:mm:ss");

        public String UpdateTimeStr => UpdateTime.ToString("yyyy/MM/dd HH:mm:ss");

        public int GetTypeCode()
        {
            return this.ItemTypeCode;
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
}
