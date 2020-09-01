using HardwareLedger.DBObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger
{
    public class Relation : DBObject.Relation, IPgmRow
    {
        public Reserve Reserve { get; set; }

        public Malfunction Malfunction { get; set; }

        public IPgmRow DownCastToIPgmRow(DBData data)
        {
            foreach (var column in data.Properties())
                this[column] = data[column];

            return this;
        }

        public bool PossibleDownCast<T>() where T : DBData, new()
        {
            var tt = new T();
            return tt is DBObject.Relation;
        }

        public DBData UpCastToDBData()
        {
            var dbdata = new DBObject.Relation();

            foreach (var column in dbdata.Properties())
                dbdata[column] = this[column];

            return dbdata;
        }
    }
}
