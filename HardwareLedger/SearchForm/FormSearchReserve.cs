﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public partial class FormSearchReserve : Form
    {
        public IReserveReceiver Receiver;

        public List<Reserve> Reserves { get; set; }

        private BindingList<ReserveListRow> bindinglist;

        private static FormSearchReserve instance;

        public static FormSearchReserve Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormSearchReserve();

                return instance;
            }
        }

        private FormSearchReserve()
        {
            InitializeComponent();

            dgvReserveList.AutoGenerateColumns = false;
            dgvReserveList.AllowUserToAddRows = false;

            this.bindinglist = new BindingList<ReserveListRow>();
            this.Reserves = new List<Reserve>();

            InitDataGridView();
            SetDataGridView();

            dgvReserveList.RowPrePaint += dgvReserveList_RowPrePaint;
            dgvReserveList.CellDoubleClick += dgvReserveList_CellDoubleClick;

            this.FormClosing += FormSearchReserve_FormClosing;
            this.Activated += FormSearchReserve_Activated;
        }

        private void dgvReserveList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvReserveList.Rows[e.RowIndex].DefaultCellStyle.BackColor = bindinglist[e.RowIndex].State?.StateColorValue ?? Color.White;
        }

        private void dgvReserveList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && Receiver != null)
            {
                Receiver.SetResult(bindinglist[e.RowIndex]);
                this.Visible = false;
            }
        }

        private void FormSearchReserve_Activated(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void FormSearchReserve_FormClosing(object sender, FormClosingEventArgs e)
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
            chCollectSchedule.DataPropertyName = nameof(ReserveListRow.CollectStateStr);
            chReserveShipping.DataPropertyName = nameof(ReserveListRow.ShippingStateStr);
            chReserveInsertTime.DataPropertyName = nameof(ReserveListRow.InsertTimeStr);
            chReserveUpdateTime.DataPropertyName = nameof(ReserveListRow.UpdateTimeStr);
        }

        private void SetDataGridView()
        {
            bindinglist.Clear();

            foreach (var row in Reserves)
                bindinglist.Add(row);

            dgvReserveList.DataSource = bindinglist;
        }

        private class ReserveListRow
        {
            public int ReserveCode { get; set; }

            public string Name { get; set; }

            public ItemType Type { get; set; }

            public string TypeStr => Type?.ItemTypeName ?? String.Empty;

            public ItemState State { get; set; }

            public string StateStr => State?.StateName ?? String.Empty;

            public CollectState CollectState { get; set; }

            public string CollectStateStr => CollectState.ViewValue;

            public ShippingState ShippingState { get; set; }

            public string ShippingStateStr => ShippingState.ViewValue;

            public DateTime InsertTime { get; set; }

            public String InsertTimeStr => InsertTime.ToString("yyyy/MM/dd HH:mm:ss");

            public DateTime UpdateTime { get; set; }

            public String UpdateTimeStr => UpdateTime.ToString("yyyy/MM/dd HH:mm:ss");

            public static implicit operator ReserveListRow(Reserve res)
            {
                var row = new ReserveListRow();

                row.ReserveCode = res.ReserveCode;
                row.Name = res.Name;
                row.State = DBAccessor.Instance.ItemStates.Where(x => x.ItemStateCode == res.ItemStateCode).FirstOrDefault();
                row.Type = DBAccessor.Instance.ItemTypes.Where(x => x.ItemTypeCode == res.ItemTypeCode).FirstOrDefault();
                row.CollectState = new CollectState(res);
                row.ShippingState = new ShippingState(res);
                row.InsertTime = res.InsertTime;
                row.UpdateTime = res.UpdateTime;

                return row;
            }

            public static implicit operator Reserve(ReserveListRow row)
            {
                var res = new Reserve();

                res.ReserveCode = row.ReserveCode;
                res.Name = row.Name;
                res.ItemStateCode = row.State?.ItemStateCode ?? 0;
                res.ItemTypeCode = row.Type?.ItemTypeCode ?? 0;
                res.InsertTime = row.InsertTime;
                res.UpdateTime = row.UpdateTime;

                return res;
            }
        }
    }
}
