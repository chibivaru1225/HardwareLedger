using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    [JsonObject("Reserve")]
    public class Reserve : DBData
    {
        [JsonProperty("ReserveCode")]
        public int ReserveCode { get; set; }

        [JsonProperty("ItemTypeCode")]
        public int ItemTypeCode { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("StateCode")]
        public int StateCode { get; set; }

        [JsonProperty("InsertTime")]
        public DateTime InsertTime { get; set; }

        [JsonProperty("UpdateTime")]
        public DateTime UpdateTime { get; set; }

        public override string GetKeyColumnName() => nameof(ReserveCode);

        public override DBData ConvertDBData<T>(T pgmrow)
        {
            if (pgmrow is HardwareLedger.Reserve reserve)
            {
                return reserve;
            }

            return null;
        }

        public override IEnumerable<string> Properties()
        {
            yield return nameof(ReserveCode);
            yield return nameof(ItemTypeCode);
            yield return nameof(Name);
            yield return nameof(StateCode);
            yield return nameof(InsertTime);
            yield return nameof(UpdateTime);
        }
    }
}
