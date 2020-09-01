using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger.Database
{
    public class CollectMalfunctionSchedule : PgmRow
    {
        public int CollectMalfuncitonScheduleCode { get; set; }

        public int ReserveCode { get; set; }

        public int ItemStateCode { get; set; }

        public int ItemTypeCode { get; set; }

        public DateTime CollectScheduleTime { get; set; }

        public DateTime InsertTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public override D Convert<D>()
        {
            throw new NotImplementedException();
        }

        public override PgmRow Convert<D>(D data)
        {
            throw new NotImplementedException();
        }

        public override bool Convertible<D>()
        {
            throw new NotImplementedException();
        }
    }
}
