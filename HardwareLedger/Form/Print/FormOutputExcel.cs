using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareLedger
{
    public partial class FormOutputExcel : Form
    {
        private static FormOutputExcel instance;

        public static FormOutputExcel Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormOutputExcel();

                return instance;
            }
        }

        private FormOutputExcel()
        {
            InitializeComponent();

            this.btnOutputExcel.Click += btnOutputExcel_Click;
            this.FormClosing += FormOutputExcel_FormClosing;
        }

        private void btnOutputExcel_Click(object sender, EventArgs e)
        {
            var file = Excel.CreateHardwareLedger();
            Process.Start(file);
        }

        private void FormOutputExcel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }
    }
}
