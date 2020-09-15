using HardwareLedger.DBObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public class ItemState : DBObject.ItemState, IPgmRow
    {
        public ApplyKbn ApplyKbnValue 
        { 
            get
            {
                return new ApplyKbn(this.ApplyKbn);
            }
            set
            {
                this.ApplyKbn = value.DBValue;
            }
        }

        public Color StateColorValue
        {
            get
            {
                return Color.FromArgb(StateColor);
            }
            set
            {
                StateColor = value.ToArgb();
            }
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
            return tt is DBObject.ItemState;
        }

        public DBData UpCastToDBData()
        {
            var dbdata = new DBObject.ItemState();

            foreach (var column in dbdata.Properties())
                dbdata[column] = this[column];

            return dbdata;
        }
    }

    public interface IStateCode
    {
        int StateCode { get; set; }
    }
}
