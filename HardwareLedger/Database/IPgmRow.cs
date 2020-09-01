using HardwareLedger.DBObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger
{
    public interface IPgmRow
    {
        DBData UpCastToDBData();

        IPgmRow DownCastToIPgmRow(DBData data);

        bool PossibleDownCast<T>() where T : DBData, new();
    }
}
