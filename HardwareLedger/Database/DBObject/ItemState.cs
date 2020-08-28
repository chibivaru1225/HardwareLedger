using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    public class ItemState : DBData
    {
        public int StateCode { get; set; }

        public int ApplyKbn { get; set; }

        public string StateName { get; set; }

        public int StateColor { get; set; }

        public override string GetKeyColumnName() => nameof(StateCode);

        public override DBData ConvertDBData<T>(T pgmrow)
        {
            if (pgmrow is HardwareLedger.ItemState state)
            {
                return state;
            }

            return null;
        }

        public override IEnumerable<string> Properties()
        {
            yield return nameof(StateCode);
            yield return nameof(ApplyKbn);
            yield return nameof(StateName);
            yield return nameof(StateColor);
        }
    }
}
