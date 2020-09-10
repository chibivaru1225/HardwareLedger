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
    public partial class FormShippingList : Form
    {
        private BindingList<ShippingRow> bindinglist;

        private static FormShippingList instance;

        public static FormShippingList Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormShippingList();

                return instance;
            }
        }

        private FormShippingList()
        {
            InitializeComponent();

            dgvShippingList.AutoGenerateColumns = false;
            dgvShippingList.AllowUserToAddRows = false;

            bindinglist = new BindingList<ShippingRow>();

            this.FormClosing += FormShippingList_FormClosing;
            this.Activated += FormShippingList_Activated;

            dgvShippingList.RowPrePaint += dgvShippingList_RowPrePaint;
            dgvShippingList.CellDoubleClick += dgvShippingList_CellDoubleClick;

            InitDataGridView();
            SetDataGridView();
        }

        private void FormShippingList_Activated(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void FormShippingList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void dgvShippingList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvShippingList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvShippingList.Rows[e.RowIndex].DefaultCellStyle.BackColor = bindinglist[e.RowIndex].State.StateColorValue;
        }

        private void SetDataGridView()
        {
            bindinglist.Clear();

            foreach (var row in DBAccessor.Instance.ReserveShippings)
                bindinglist.Add(row);

            dgvShippingList.DataSource = bindinglist;
        }

        private void InitDataGridView()
        {
            chReserveCode.DataPropertyName = nameof(ShippingRow.ReserveCodeStr);
            chShippingCode.DataPropertyName = nameof(ShippingRow.ShippingCodeStr);
            chState.DataPropertyName = nameof(ShippingRow.StateStr);
            chShopCode.DataPropertyName = nameof(ShippingRow.ShopStr);
            chShippingTime.DataPropertyName = nameof(ShippingRow.ShippingTimeStr);
            chInsertTime.DataPropertyName = nameof(ShippingRow.InsertTimeStr);
            chUpdateTime.DataPropertyName = nameof(ShippingRow.UpdateTimeStr);
        }

        private class ShippingRow
        {
            public int ShippingCode { get; set; }

            public string ShippingCodeStr => ShippingCode.ToString();

            public int ReserveCode { get; set; }

            public string ReserveCodeStr => ReserveCode.ToString();

            public ShopType Shop { get; set; }

            public string ShopStr => Shop?.ShopNum ?? String.Empty;

            public ItemState State { get; set; }

            public string StateStr => State?.StateName ?? String.Empty;

            public DateTime ShippingTime { get; set; }

            public String ShippingTimeStr => ShippingTime.ToString("yyyy/MM/dd HH:mm:ss");

            public DateTime InsertTime { get; set; }

            public String InsertTimeStr => InsertTime.ToString("yyyy/MM/dd HH:mm:ss");

            public DateTime UpdateTime { get; set; }

            public String UpdateTimeStr => UpdateTime.ToString("yyyy/MM/dd HH:mm:ss");

            public static implicit operator ShippingRow(ReserveShipping res)
            {
                var row = new ShippingRow();

                row.ShippingCode = res.ReserveShippingCode;
                row.ReserveCode = res.ReserveCode;
                row.State = DBAccessor.Instance.GetItemState(res);
                row.Shop = DBAccessor.Instance.GetShop(res);
                row.ShippingTime = res.ShippingTime;
                row.InsertTime = res.InsertTime;
                row.UpdateTime = res.UpdateTime;

                return row;
            }

            public static implicit operator ReserveShipping(ShippingRow row)
            {
                var res = new ReserveShipping();

                //res.CollectScheduleCode = row.ScheduleCode;
                //res.RelationCode = row.RelationCode;
                //res.ItemTypeCode = row.Type.ItemTypeCode;
                //res.ItemStateCode = row.State.ItemStateCode;
                //res.ShopCode = row.Shop.ShopCode;
                //res.CollectScheduleTime = row.CollectScheduleDate;
                //res.CollectTime = row.CollectDate;
                //row.InsertTime = row.InsertTime;
                //row.UpdateTime = row.UpdateTime;

                return res;
            }
        }
    }
}
