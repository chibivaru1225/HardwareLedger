using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    [Table("ItemType")]
    public class ItemType : DBData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int ItemTypeCode { get; set; }

        [Required]
        public String ItemTypeName { get; set; }

        public override string GetKeyColumnName() => nameof(ItemTypeCode);

        public override IEnumerable<string> Properties()
        {
            yield return nameof(ItemTypeCode);
            yield return nameof(ItemTypeName);
        }
    }
}
