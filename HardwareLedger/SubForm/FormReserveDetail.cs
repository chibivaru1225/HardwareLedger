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
    public partial class FormReserveDetail : Form
    {
        private static FormReserveDetail instance;

        public static FormReserveDetail Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormReserveDetail();

                return instance;
            }
        }

        private FormReserveDetail()
        {
            InitializeComponent();

            this.FormClosing += FormReserveDetail_FormClosing;
        }

        private void FormReserveDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }
    }
}
