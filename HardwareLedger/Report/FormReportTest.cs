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

        public FormReportTest(ReportRow row)
        {
            InitializeComponent();

            this.FormClosing += FormReportTest_FormClosing;
            this.row = row;
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
            this.ReportRowBindingSource.Clear();
            this.reportViewer1.RefreshReport();

            this.ReportRowBindingSource.Add(this.row);
            this.reportViewer1.RefreshReport();
        }

        /// <summary>
        /// ラベル印刷用行
        /// </summary>
        public class ReportRow
        {
            public string Type { get; set; }

            public string Name { get; set; }

            public string ModelNo { get; set; }

            public string State { get; set; }

            public string Zaiko { get; set; }

            public string Code { get; set; }


            /// <summary>
            /// 予備機→ラベル印刷用行変換
            /// </summary>
            /// <param name="res"></param>
            public static implicit operator ReportRow(Reserve res)
            {
                var row = new ReportRow();

                row.State = "予備機";
                row.Type = DBAccessor.Instance.GetItemType(res).ItemTypeName;
                row.Name = res.Name;
                row.ModelNo = res.ModelNo;
                row.Zaiko = res.Zaiko.ViewValue;
                row.Code = String.Format("{0:D8}", res.ReserveCode);

                return row;
            }

            /// <summary>
            /// 故障機→ラベル印刷用行変換
            /// </summary>
            /// <param name="mal"></param>
            public static implicit operator ReportRow(Malfunction mal)
            {
                var row = new ReportRow();

                row.State = "故障機";
                row.Type = DBAccessor.Instance.GetItemType(mal).ItemTypeName;
                row.Name = mal.Name;
                row.ModelNo = mal.ModelNo;
                row.Zaiko = mal.Zaiko.ViewValue;
                row.Code = String.Format("{0:D8}", mal.MalfunctionCode);

                return row;
            }
        }
    }
}
