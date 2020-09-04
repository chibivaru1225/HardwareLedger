using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareLedger
{
    public partial class FormReserveShippingRegister : Form
    {
        private static FormReserveShippingRegister instance;

        public static FormReserveShippingRegister Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormReserveShippingRegister();

                return instance;
            }
        }

        private FormReserveShippingRegister()
        {
            InitializeComponent();
        }
    }
}
