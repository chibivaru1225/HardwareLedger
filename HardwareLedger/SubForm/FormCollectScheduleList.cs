using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareLedger.SubForm
{
    public partial class FormCollectScheduleList : Form
    {
        private static FormCollectScheduleList instance;

        public static FormCollectScheduleList Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormCollectScheduleList();

                return instance;
            }
        }

        private FormCollectScheduleList()
        {
            InitializeComponent();
        }
    }
}
