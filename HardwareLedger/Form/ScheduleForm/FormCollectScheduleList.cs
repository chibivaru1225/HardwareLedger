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
    public partial class FormCollectScheduleList : Form, ISearchConditionReceiver<FormCollectScheduleList.ScheduleRow>
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
            dgvCollectScheduleList.CellDoubleClick += dgvCollectScheduleList_CellDoubleClick;

            InitDataGridView();
            SetDataGridView();
        }

        private void dgvCollectScheduleList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FormCollectScheduleRegister.Instance.Relation = DBAccessor.Instance.GetRelation(bindinglist[e.RowIndex]);
                FormCollectScheduleRegister.Instance.Malfunction = DBAccessor.Instance.GetMalfunction(bindinglist[e.RowIndex]);
                FormCollectScheduleRegister.Instance.Reserve = DBAccessor.Instance.GetReserve(bindinglist[e.RowIndex]);
                FormCollectScheduleRegister.Instance.Show();
            }
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

        public void SetSortedList(IEnumerable<ScheduleRow> list)
        {
        }

        public class ScheduleRow : DataGridViewRowBase, IListOrder
        {
            public int ScheduleCode { get; set; }

            public int RelationCode { get; set; }

            public int? ReserveCode { get; set; }

            public string ReserveCodeStr => ReserveCode == null ? "-" : ReserveCode.Value.ToString();

            public int? MalfunctionCode { get; set; }

            public string MalfunctionCodeStr => MalfunctionCode == null ? "-" : MalfunctionCode.Value.ToString();

            public ItemType Type { get; set; }

            public string TypeStr => Type?.ItemTypeName ?? String.Empty;

            public int? TypeCode => Type?.ItemTypeCode;

            public ItemState State { get; set; }

            public string StateStr => State?.StateName ?? String.Empty;

            public int? StateCode => State?.ItemStateCode;

            public ShopType Shop { get; set; }

            public string ShopStr => Shop?.ShopNum ?? String.Empty;

            public int? ShopCode => Shop?.ShopCode;

            public DateTime CollectScheduleDate { get; set; }

            public String CollectScheduleDateStr => CollectScheduleDate.ToString("yyyy/MM/dd");

            public DateTime? CollectDate { get; set; }

            public String CollectDateStr => CollectDate == null ? "-" : CollectDate.Value.ToString("yyyy/MM/dd");

            public DateTime InsertTime { get; set; }

            public String InsertTimeStr => InsertTime.ToString("yyyy/MM/dd HH:mm:ss");

            public DateTime UpdateTime { get; set; }

            public String UpdateTimeStr => UpdateTime.ToString("yyyy/MM/dd HH:mm:ss");

            public IEnumerable<SortOrderProperties> RelatedProperties
            {
                get
                {
                    yield return new SortOrderProperties() { ComboboxColumnName = "回収予定コード", CellValueName = nameof(ScheduleCode), InnerValueName = nameof(ScheduleCode) };
                    yield return new SortOrderProperties() { ComboboxColumnName = "予備機コード", CellValueName = nameof(ReserveCodeStr), InnerValueName = nameof(ReserveCode) };
                    yield return new SortOrderProperties() { ComboboxColumnName = "故障機コード", CellValueName = nameof(MalfunctionCodeStr), InnerValueName = nameof(MalfunctionCode) };
                    yield return new SortOrderProperties() { ComboboxColumnName = "種別", CellValueName = nameof(TypeStr), InnerValueName = nameof(TypeCode) };
                    yield return new SortOrderProperties() { ComboboxColumnName = "状態", CellValueName = nameof(StateStr), InnerValueName = nameof(StateCode) };
                    yield return new SortOrderProperties() { ComboboxColumnName = "店舗", CellValueName = nameof(ShopStr), InnerValueName = nameof(ShopCode) };
                    yield return new SortOrderProperties() { ComboboxColumnName = "回収予定日時", CellValueName = nameof(CollectScheduleDateStr), InnerValueName = nameof(CollectScheduleDate) };
                    yield return new SortOrderProperties() { ComboboxColumnName = "回収日時", CellValueName = nameof(CollectDateStr), InnerValueName = nameof(CollectDate) };
                    yield return new SortOrderProperties() { ComboboxColumnName = "追加日時", CellValueName = nameof(InsertTimeStr), InnerValueName = nameof(InsertTime) };
                    yield return new SortOrderProperties() { ComboboxColumnName = "変更日時", CellValueName = nameof(UpdateTimeStr), InnerValueName = nameof(UpdateTime) };
                }
            }

            public override IEnumerable<string> Properties()
            {
                yield return nameof(ScheduleCode);
                yield return nameof(RelationCode);
                yield return nameof(ReserveCode);
                yield return nameof(ReserveCodeStr);
                yield return nameof(MalfunctionCode);
                yield return nameof(MalfunctionCodeStr);
                yield return nameof(Type);
                yield return nameof(TypeStr);
                yield return nameof(State);
                yield return nameof(StateStr);
                yield return nameof(CollectScheduleDate);
                yield return nameof(CollectScheduleDateStr);
                yield return nameof(CollectDate);
                yield return nameof(CollectDateStr);
                yield return nameof(InsertTime);
                yield return nameof(InsertTimeStr);
                yield return nameof(UpdateTime);
                yield return nameof(UpdateTimeStr);
            }

            public static implicit operator ScheduleRow(CollectSchedule res)
            {
                var row = new ScheduleRow();

                row.ScheduleCode = res.CollectScheduleCode;
                row.RelationCode = res.RelationCode;
                row.ReserveCode = DBAccessor.Instance.GetRelation(res).ReserveCode;
                row.MalfunctionCode = DBAccessor.Instance.GetRelation(res).MalfunctionCode;
                row.State = DBAccessor.Instance.GetItemState(res);
                row.Type = DBAccessor.Instance.GetItemType(res);
                row.Shop = DBAccessor.Instance.GetShop(res);
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
