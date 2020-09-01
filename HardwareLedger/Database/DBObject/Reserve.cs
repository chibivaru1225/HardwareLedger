using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    [Table("Reserve")]
    public class Reserve : DBData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [JsonProperty]
        public int ReserveCode { get; set; }

        [Required]
        public int ItemTypeCode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int StateCode { get; set; }

        [Required]
        public DateTime InsertTime { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }

        public override string GetKeyColumnName() => nameof(ReserveCode);

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
