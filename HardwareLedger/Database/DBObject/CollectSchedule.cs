using HardwareLedger.DBObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    [Table("CollectSchedule")]
    public class CollectSchedule : DBData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int CollectScheduleCode { get; set; }

        [Required]
        public int RelationCode { get; set; }

        [Required]
        public int ItemStateCode { get; set; }

        [Required]
        public int ItemTypeCode { get; set; }

        [Required]
        public DateTime CollectScheduleTime { get; set; }

        [Required]
        public DateTime? CollectTime { get; set; }

        [Required]
        public DateTime InsertTime { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }

        public override string GetKeyColumnName() => nameof(CollectScheduleCode);

        public override IEnumerable<string> Properties()
        {
            yield return nameof(CollectScheduleCode);
            yield return nameof(RelationCode);
            yield return nameof(ItemStateCode);
            yield return nameof(ItemTypeCode);
            yield return nameof(CollectScheduleTime);
            yield return nameof(CollectTime);
            yield return nameof(InsertTime);
            yield return nameof(UpdateTime);
        }
    }
}
