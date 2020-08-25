using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();

            var kbna1 = new ApplyKbn(ApplyKbns.Reserve | ApplyKbns.Malfunction);
            var kbna2 = new ApplyKbn(ApplyKbns.Reserve);
            var kbna3 = new ApplyKbn(ApplyKbns.Malfunction);
            var kbna4 = new ApplyKbn(ApplyKbns.Reserve & ApplyKbns.Malfunction);

            var kbnb1 = new ApplyKbn(0);
            var kbnb2 = new ApplyKbn(1);
            var kbnb3 = new ApplyKbn(2);
            var kbnb4 = new ApplyKbn(3);

            var ac = JSONAccessor.Instance;
        }
    }
}
