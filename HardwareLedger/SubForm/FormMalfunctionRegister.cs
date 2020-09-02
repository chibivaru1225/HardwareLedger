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
    public partial class FormMalfunctionRegister : Form
    {
        public Relation Relation { get; set; }

        private static FormMalfunctionRegister instance;

        public static FormMalfunctionRegister Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormMalfunctionRegister();

                return instance;
            }
        }

        private FormMalfunctionRegister()
        {
            InitializeComponent();
        }
    }
}
