using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    [Table("Malfunction")]
    public class Malfunction : DBData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int MalfunctionCode { get; set; }

        [Required]
        public int ItemTypeCode { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public int ItemStateCode { get; set; }

        [Required]
        public int ShopCode { get; set; }

        [Required]
        public DateTime InsertTime { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }

        public override string GetKeyColumnName() => nameof(MalfunctionCode);

        public override IEnumerable<string> Properties()
        {
            yield return nameof(MalfunctionCode);
            yield return nameof(ItemTypeCode);
            yield return nameof(Name);
            yield return nameof(ItemStateCode);
            yield return nameof(ShopCode);
            yield return nameof(InsertTime);
            yield return nameof(UpdateTime);
        }
    }
}
