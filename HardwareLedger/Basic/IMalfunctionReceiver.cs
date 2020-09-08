using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareLedger
{
    public interface IMalfunctionReceiver
    {
        void SetResult(Malfunction mal);
    }
}
