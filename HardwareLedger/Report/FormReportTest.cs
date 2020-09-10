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
    public partial class FormReportTest : Form
    {
        private ReportRow row;

        private static FormReportTest instance;

        public static FormReportTest Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormReportTest();

                return instance;
            }
        }

        public void SetData(ReportRow row)
        {
            this.row = row;
        }

        private FormReportTest()
        {
            InitializeComponent();

            this.FormClosing += FormReportTest_FormClosing;
        }

        private void FormReportTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void FormReportTest_Load(object sender, EventArgs e)
        {
            this.ReportRowBindingSource.Add(this.row);
            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            //this.reportViewer1.Report
        }

        public class ReportRow
        {
            public string Type { get; set; }

            public string Name { get; set; }

            public string ModelNo { get; set; }

            public string State { get; set; }


            public static implicit operator ReportRow(Reserve res)
            {
                var row = new ReportRow();

                row.State = "予備機";
                row.Type = DBAccessor.Instance.GetItemType(res).ItemTypeName;
                row.Name = res.Name;
                row.ModelNo = res.ModelNo;

                return row;
            }

            public static implicit operator ReportRow(Malfunction mal)
            {
                var row = new ReportRow();

                row.State = "故障機";
                row.Type = DBAccessor.Instance.GetItemType(mal).ItemTypeName;
                row.Name = mal.Name;
                row.ModelNo = mal.ModelNo;

                return row;
            }
        }
    }
}
