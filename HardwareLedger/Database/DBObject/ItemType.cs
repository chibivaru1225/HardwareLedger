using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    [JsonObject("ItemType")]
    public class ItemType : DBData
    {
        [JsonProperty("ItemTypeCode")]
        public int ItemTypeCode { get; set; }

        [JsonProperty("ItemTypeName")]
        public String ItemTypeName { get; set; }
        public override string GetKeyColumnName() => nameof(ItemTypeCode);

        public override DBData ConvertDBData<T>(T pgmrow)
        {
            if (pgmrow is HardwareLedger.ItemType reserve)
            {
                return reserve;
            }

            return null;
        }

        public override IEnumerable<string> Properties()
        {
            yield return nameof(ItemTypeCode);
            yield return nameof(ItemTypeName);
        }
    }
}
