using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareLedger
{
    public partial class FormReserveList : Form
    {
        private static FormReserveList instance;

        public static FormReserveList Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormReserveList();

                return instance;
            }
        }

        private FormReserveList()
        {
            InitializeComponent();

            dgvReserveList.AutoGenerateColumns = false;
            dgvReserveList.AllowUserToAddRows = false;

            InitDataGridView();
            SetDataGridView();

            this.FormClosing += FormReserveList_FormClosing;
            this.Activated += FormReserveList_Activated;
        }

        private void FormReserveList_Activated(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void FormReserveList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void InitDataGridView()
        {
            chReserveCode.DataPropertyName = nameof(ReserveListRow.ReserveCode);
            chReserveName.DataPropertyName = nameof(ReserveListRow.Name);
            chReserveType.DataPropertyName = nameof(ReserveListRow.TypeStr);
            chReserveState.DataPropertyName = nameof(ReserveListRow.StateStr);
            chReserveInsertTime.DataPropertyName = nameof(ReserveListRow.InsertTimeStr);
            chReserveUpdateTime.DataPropertyName = nameof(ReserveListRow.UpdateTimeStr);
        }

        private void SetDataGridView()
        {
            var list = new List<ReserveListRow>();

            foreach (var row in JSONAccessor.Instance.Reserves)
                list.Add(row);

            dgvReserveList.DataSource = list;
        }

        private class ReserveListRow
        {
            public int ReserveCode { get; set; }

            public string Name { get; set; }

            public ItemType Type { get; set; }

            public string TypeStr => Type?.ItemTypeName ?? String.Empty;

            public ItemState State { get; set; }

            public string StateStr => State?.StateName ?? String.Empty;

            public DateTime InsertTime { get; set; }

            public String InsertTimeStr => InsertTime.ToString("yyyy/MM/dd HH:mm:ss");

            public DateTime UpdateTime { get; set; }

            public String UpdateTimeStr => UpdateTime.ToString("yyyy/MM/dd HH:mm:ss");

            public static implicit operator ReserveListRow(Reserve res)
            {
                var row = new ReserveListRow();

                row.ReserveCode = res.ReserveCode;
                row.Name = res.Name;
                row.State = JSONAccessor.Instance.ItemStates.Where(x => x.StateCode == res.StateCode).FirstOrDefault();
                row.Type = JSONAccessor.Instance.ItemTypes.Where(x => x.ItemTypeCode == res.ItemTypeCode).FirstOrDefault();
                row.InsertTime = res.InsertTime;
                row.UpdateTime = res.UpdateTime;

                return row;
            }

            public static implicit operator Reserve(ReserveListRow row)
            {
                var res = new Reserve();

                res.ReserveCode = row.ReserveCode;
                res.Name = row.Name;
                res.StateCode = row.State.StateCode;
                res.ItemTypeCode = row.Type.ItemTypeCode;
                res.InsertTime = row.InsertTime;
                res.UpdateTime = row.UpdateTime;

                return res;
            }
        }
    }
}
