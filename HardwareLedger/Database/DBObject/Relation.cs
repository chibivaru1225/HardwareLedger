using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    [Table("Relation")]
    public class Relation : DBData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int RelationCode { get; set; }

        [Required]
        public int? ReserveCode { get; set; }

        [Required]
        public int? MalfunctionCode { get; set; }

        public override string GetKeyColumnName() => nameof(RelationCode);

        public override IEnumerable<string> Properties()
        {
            yield return nameof(RelationCode);
            yield return nameof(ReserveCode);
            yield return nameof(MalfunctionCode);
        }
    }
}
