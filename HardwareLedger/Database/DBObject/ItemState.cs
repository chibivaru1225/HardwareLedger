using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    [Table("ItemState")]
    public class ItemState : DBData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int StateCode { get; set; }

        [Required]
        public int ApplyKbn { get; set; }

        [Required]
        public string StateName { get; set; }

        [Required]
        public int StateColor { get; set; }

        public override string GetKeyColumnName() => nameof(StateCode);

        public override IEnumerable<string> Properties()
        {
            yield return nameof(StateCode);
            yield return nameof(ApplyKbn);
            yield return nameof(StateName);
            yield return nameof(StateColor);
        }
    }
}
