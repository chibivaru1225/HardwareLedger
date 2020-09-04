using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    public class ShopType : DBData
    {
        public int ShopCode { get; set; }

        public string ShopNum { get; set; }

        public string ShopName { get; set; }

        public bool Enable { get; set; }

        public override string GetKeyColumnName() => nameof(ShopCode);

        public override IEnumerable<string> Properties()
        {
            yield return nameof(ShopCode);
            yield return nameof(ShopNum);
            yield return nameof(ShopName);
            yield return nameof(Enable);
        }
    }
}
