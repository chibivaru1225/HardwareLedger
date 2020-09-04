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
    public partial class FormCollectScheduleList : Form
    {
        private BindingList<ScheduleRow> bindinglist;

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

            dgvCollectScheduleList.AutoGenerateColumns = false;
            dgvCollectScheduleList.AllowUserToAddRows = false;

            bindinglist = new BindingList<ScheduleRow>();

            this.FormClosing += FormCollectScheduleList_FormClosing;
            this.Activated += FormCollectScheduleList_Activated;

            dgvCollectScheduleList.RowPrePaint += dgvCollectScheduleList_RowPrePaint;

            InitDataGridView();
            SetDataGridView();
        }

        private void dgvCollectScheduleList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvCollectScheduleList.Rows[e.RowIndex].DefaultCellStyle.BackColor = bindinglist[e.RowIndex].State.StateColorValue;
        }

        private void FormCollectScheduleList_Activated(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void FormCollectScheduleList_FormClosing(object sender, FormClosingEventArgs e)
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

            foreach (var row in DBAccessor.Instance.CollectSchedules)
                bindinglist.Add(row);

            dgvCollectScheduleList.DataSource = bindinglist;
        }

        private void InitDataGridView()
        {
            chReserveCode.DataPropertyName = nameof(ScheduleRow.ReserveCodeStr);
            chMalfunctionCode.DataPropertyName = nameof(ScheduleRow.MalfunctionCodeStr);
            chItemType.DataPropertyName = nameof(ScheduleRow.TypeStr);
            chItemState.DataPropertyName = nameof(ScheduleRow.StateStr);
            chShop.DataPropertyName = nameof(ScheduleRow.ShopStr);
            chCollectDate.DataPropertyName = nameof(ScheduleRow.CollectDateStr);
            chCollectScheduleDate.DataPropertyName = nameof(ScheduleRow.CollectScheduleDateStr);
            chInsertTime.DataPropertyName = nameof(ScheduleRow.InsertTimeStr);
            chUpdateTime.DataPropertyName = nameof(ScheduleRow.UpdateTimeStr);
        }

        private class ScheduleRow
        {
            public int ScheduleCode { get; set; }

            public int RelationCode { get; set; }

            public int? ReserveCode { get; set; }

            public string ReserveCodeStr => ReserveCode == null ? "-" : ReserveCode.Value.ToString();

            public int? MalfunctionCode { get; set; }

            public string MalfunctionCodeStr => MalfunctionCode == null ? "-" : MalfunctionCode.Value.ToString();

            public ItemType Type { get; set; }

            public string TypeStr => Type?.ItemTypeName ?? String.Empty;

            public ItemState State { get; set; }

            public string StateStr => State?.StateName ?? String.Empty;

            public ShopType Shop { get; set; }

            public string ShopStr => Shop?.ShopNum ?? String.Empty;

            public DateTime CollectScheduleDate { get; set; }

            public String CollectScheduleDateStr => CollectScheduleDate.ToString("yyyy/MM/dd");

            public DateTime? CollectDate { get; set; }

            public String CollectDateStr => CollectDate == null ? "-" : CollectDate.Value.ToString("yyyy/MM/dd");

            public DateTime InsertTime { get; set; }

            public String InsertTimeStr => InsertTime.ToString("yyyy/MM/dd HH:mm:ss");

            public DateTime UpdateTime { get; set; }

            public String UpdateTimeStr => UpdateTime.ToString("yyyy/MM/dd HH:mm:ss");

            public static implicit operator ScheduleRow(CollectSchedule res)
            {
                var row = new ScheduleRow();

                row.ScheduleCode = res.CollectScheduleCode;
                row.RelationCode = res.RelationCode;
                row.ReserveCode = DBAccessor.Instance.GetRelation(res).ReserveCode;
                row.MalfunctionCode = DBAccessor.Instance.GetRelation(res).MalfunctionCode;
                row.State = DBAccessor.Instance.ItemStates.Where(x => x.ItemStateCode == res.ItemStateCode).FirstOrDefault();
                row.Type = DBAccessor.Instance.ItemTypes.Where(x => x.ItemTypeCode == res.ItemTypeCode).FirstOrDefault();
                row.Shop = DBAccessor.Instance.ShopTypes.Where(x => x.ShopCode == res.ShopCode).FirstOrDefault();
                row.CollectScheduleDate = res.CollectScheduleTime;
                row.CollectDate = res.CollectTime;
                row.InsertTime = res.InsertTime;
                row.UpdateTime = res.UpdateTime;

                return row;
            }

            public static implicit operator CollectSchedule(ScheduleRow row)
            {
                var res = new CollectSchedule();

                res.CollectScheduleCode = row.ScheduleCode;
                res.RelationCode = row.RelationCode;
                res.ItemTypeCode = row.Type.ItemTypeCode;
                res.ItemStateCode = row.State.ItemStateCode;
                res.ShopCode = row.Shop.ShopCode;
                res.CollectScheduleTime = row.CollectScheduleDate;
                res.CollectTime = row.CollectDate;
                row.InsertTime = row.InsertTime;
                row.UpdateTime = row.UpdateTime;

                return res;
            }
        }
    }
}
