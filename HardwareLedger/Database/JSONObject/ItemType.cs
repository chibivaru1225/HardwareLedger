using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.JSONObject
{
    [JsonObject("ItemType")]
    public class ItemType : IJSONData
    {
        [JsonProperty("ItemTypeCode")]
        public int ItemTypeCode { get; set; }

        [JsonProperty("ItemTypeName")]
        public String ItemTypeName { get; set; }
    }
}
