﻿using Microsoft.Win32.SafeHandles;
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
        public string ModelNo { get; set; }

        [Required]
        public int ItemStateCode { get; set; }

        [Required]
        public string ZaikoKbn { get; set; }

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
            yield return nameof(ModelNo);
            yield return nameof(ItemStateCode);
            yield return nameof(ZaikoKbn);
            yield return nameof(InsertTime);
            yield return nameof(UpdateTime);
        }
    }
}
