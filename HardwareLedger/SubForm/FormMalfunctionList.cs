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
    public partial class FormMalfunctionList : Form
    {
        private BindingList<MalfunctionRow> bindinglist;

        private static FormMalfunctionList instance;

        public static FormMalfunctionList Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormMalfunctionList();

                return instance;
            }
        }

        private FormMalfunctionList()
        {
            InitializeComponent();

            dgvMalfunctionList.AutoGenerateColumns = false;
            dgvMalfunctionList.AllowUserToAddRows = false;

            bindinglist = new BindingList<MalfunctionRow>();
            //Malfunctions = new List<Malfunction>();

            this.FormClosing += FormMalfunctionList_FormClosing;
            this.Activated += FormMalfunctionList_Activated;

            dgvMalfunctionList.RowPrePaint += dgvMalfunctionList_RowPrePaint;
            dgvMalfunctionList.CellDoubleClick += dgvMalfunctionList_CellDoubleClick;


            InitDataGridView();
            SetDataGridView();
        }

        private void FormMalfunctionList_Activated(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void dgvMalfunctionList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FormMalfunctionDetail.Instance.MalfunctionDetail = bindinglist[e.RowIndex];
                FormMalfunctionDetail.Instance.Show();
            }
        }

        private void dgvMalfunctionList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvMalfunctionList.Rows[e.RowIndex].DefaultCellStyle.BackColor = bindinglist[e.RowIndex].State?.StateColorValue ?? Color.White;
        }

        private void FormMalfunctionList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void SetDataGridView()
        {
            bindinglist.Clear();

            foreach (var row in DBAccessor.Instance.Malfunctions)
                bindinglist.Add(row);

            dgvMalfunctionList.DataSource = bindinglist;
        }

        private void InitDataGridView()
        {
            chMalfunctionCode.DataPropertyName = nameof(MalfunctionRow.MalfunctionCode);
            chItemType.DataPropertyName = nameof(MalfunctionRow.TypeStr);
            chName.DataPropertyName = nameof(MalfunctionRow.Name);
            chState.DataPropertyName = nameof(MalfunctionRow.StateStr);
            chShop.DataPropertyName = nameof(MalfunctionRow.ShopStr);
            chInsertTime.DataPropertyName = nameof(MalfunctionRow.InsertTimeStr);
            chUpdateTime.DataPropertyName = nameof(MalfunctionRow.UpdateTimeStr);
        }

        private class MalfunctionRow
        {
            public int MalfunctionCode { get; set; }

            public ItemType Type { get; set; }

            public string TypeStr => Type?.ItemTypeName ?? String.Empty;

            public ItemState State { get; set; }

            public string StateStr => State?.StateName ?? String.Empty;

            public ShopType Shop { get; set; }

            public string ShopStr => Shop?.ShopNum ?? String.Empty;

            public string Name { get; set; }

            public DateTime InsertTime { get; set; }

            public String InsertTimeStr => InsertTime.ToString("yyyy/MM/dd HH:mm:ss");

            public DateTime UpdateTime { get; set; }

            public String UpdateTimeStr => UpdateTime.ToString("yyyy/MM/dd HH:mm:ss");


            public static implicit operator MalfunctionRow(Malfunction res)
            {
                var row = new MalfunctionRow();

                row.MalfunctionCode = res.MalfunctionCode;
                row.State = DBAccessor.Instance.ItemStates.Where(x => x.ItemStateCode == res.ItemStateCode).FirstOrDefault();
                row.Type = DBAccessor.Instance.ItemTypes.Where(x => x.ItemTypeCode == res.ItemTypeCode).FirstOrDefault();
                row.Shop = DBAccessor.Instance.ShopTypes.Where(x => x.ShopCode == res.ShopCode).FirstOrDefault();
                row.Name = res.Name;
                row.InsertTime = res.InsertTime;
                row.UpdateTime = res.UpdateTime;

                return row;
            }

            public static implicit operator Malfunction(MalfunctionRow row)
            {
                var res = new Malfunction();

                res.MalfunctionCode = row.MalfunctionCode;
                res.ItemTypeCode = row.Type.ItemTypeCode;
                res.Name = row.Name;
                res.ItemStateCode = row.State.ItemStateCode;
                res.ShopCode = row.Shop.ShopCode;
                res.InsertTime = row.InsertTime;
                res.UpdateTime = row.UpdateTime;

                return res;
            }
        }
    }
}
