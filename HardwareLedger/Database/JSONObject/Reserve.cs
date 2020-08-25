using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.JSONObject
{
    [JsonObject("Reserve")]
    public class Reserve : IJSONData
    {
        [JsonProperty("ReserveCode")]
        public int ReserveCode { get; set; }

        [JsonProperty("ItemTypeCode")]
        public int ItemTypeCode { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("InsertTime")]
        public DateTime InsertTime { get; set; }

        [JsonProperty("UpdateTime")]
        public DateTime UpdateTime { get; set; }
    }
}
