using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.DBObject
{
    [Table("ReserveShipping")]
    public class ReserveShipping : DBData
    {
        [Required]
        public int ReserveShippingCode { get; set; }

        [Required]
        public int ReserveCode { get; set; }

        [Required]
        public int ShopCode { get; set; }

        [Required]
        public string Biko { get; set; }

        [Required]
        public DateTime InsertTime { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }

        public override string GetKeyColumnName() => nameof(ReserveShippingCode);

        public override IEnumerable<string> Properties()
        {
            yield return nameof(ReserveShippingCode);
            yield return nameof(ReserveCode);
            yield return nameof(ShopCode);
            yield return nameof(Biko);
            yield return nameof(InsertTime);
            yield return nameof(UpdateTime);
        }
    }
}
