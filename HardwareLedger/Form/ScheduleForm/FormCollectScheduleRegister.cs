using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public partial class FormCollectScheduleRegister : Form, IReserveReceiver, IMalfunctionReceiver
    {
        public Reserve Reserve { get; set; }

        public Malfunction Malfunction { get; set; }

        public Relation Relation { get; set; }


        private static FormCollectScheduleRegister instance;

        public static FormCollectScheduleRegister Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormCollectScheduleRegister();

                return instance;
            }
        }

        private FormCollectScheduleRegister()
        {
            InitializeComponent();

            this.FormClosing += FormCollectScheduleRegister_FormClosing;
            this.VisibleChanged += FormCollectScheduleRegister_VisibleChanged;

            this.btnUpdate.Click += btnUpdate_Click;
            this.btnCancel.Click += btnCancel_Click;

            cbxType.ValueMember = nameof(ItemType.ItemTypeCode);
            cbxType.DisplayMember = nameof(ItemType.ItemTypeName);

            cbxState.ValueMember = nameof(ItemState.ItemStateCode);
            cbxState.DisplayMember = nameof(ItemState.StateName);

            cbxShop.ValueMember = nameof(ShopType.ShopCode);
            cbxShop.DisplayMember = nameof(ShopType.FullName);

            cbCollected.CheckedChanged += cbCollected_CheckedChanged;

            SetComboBoxes();

            btnReserveSelect.Click += btnReserveSelect_Click;
            btnReserveClear.Click += btnReserveClear_Click;

            btnMalfuinctionSelect.Click += btnMalfuinctionSelect_Click;
            btnMalfunctionClear.Click += btnMalfunctionClear_Click;
        }

        private void btnMalfunctionClear_Click(object sender, EventArgs e)
        {
            if (Malfunction != null && MessageBox.Show(this, "故障機紐付を解除しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Malfunction = null;
                txtMalfunctionCode.Clear();

                if (Relation != null)
                    Relation.MalfunctionCode = null;
            }
        }

        private void btnMalfuinctionSelect_Click(object sender, EventArgs e)
        {
            var mas = new List<Malfunction>();

            foreach (var row in DBAccessor.Instance.Malfunctions)
            {
                var r1 = (from a in DBAccessor.Instance.Relations
                          where a.MalfunctionCode == row.MalfunctionCode
                          select a).FirstOrDefault();

                if (r1 == null || r1.ReserveCode == null)
                {
                    mas.Add(row);
                    continue;
                }
            }

            if (mas.Count() == 0)
            {
                MessageBox.Show(this, "紐付のない故障機がありません。故障機を登録してください。", "ハードウェア管理");
            }
            else
            {
                FormSearchMalfunction.Instance.Malfunctions = mas;
                FormSearchMalfunction.Instance.Receiver = this;
                FormSearchMalfunction.Instance.Show();
            }
        }

        private void btnReserveClear_Click(object sender, EventArgs e)
        {
            if (Reserve != null && MessageBox.Show(this, "予備機紐付を解除しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Reserve = null;
                txtReserveCode.Clear();

                if (Relation != null)
                    Relation.Reserve = null;
            }
        }

        private void btnReserveSelect_Click(object sender, EventArgs e)
        {
            var res = new List<Reserve>();

            foreach (var row in DBAccessor.Instance.Reserves)
            {
                var r1 = (from a in DBAccessor.Instance.Relations
                          where a.ReserveCode == row.ReserveCode
                          select a).FirstOrDefault();

                if (r1 == null || r1.ReserveCode == null)
                {
                    res.Add(row);
                    continue;
                }
            }

            if (res.Count() == 0)
            {
                MessageBox.Show(this, "紐付のない予備機がありません。予備機を登録してください。", "ハードウェア管理");
            }
            else
            {
                FormSearchReserve.Instance.Reserves = res;
                FormSearchReserve.Instance.Receiver = this;
                FormSearchReserve.Instance.Show();
            }
        }

        private void cbCollected_CheckedChanged(object sender, EventArgs e)
        {
            dtpCollectedTime.Enabled = cbCollected.Checked;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxType.SelectedValue is int cbxtype && cbxState.SelectedValue is int cbxstate && cbxShop.SelectedValue is int cbxshop)
            {
                if (cbxshop == 0)
                {
                    MessageBox.Show(this, "店舗は必ず選択してください。", "ハードウェア管理");
                    return;
                }

                if (Relation == null)
                {
                    var rel = new Relation();
                    rel.RelationCode = DBAccessor.Instance.MaxUniqueNumber<DBObject.Relation>() + 1;
                    rel.ReserveCode = Reserve?.ReserveCode;
                    rel.MalfunctionCode = Malfunction?.MalfunctionCode;

                    DBAccessor.Instance.Relations = DBAccessor.Instance.UpsertJson<Relation, DBObject.Relation>(rel);

                    Relation = rel;

                    var cms = new CollectSchedule();
                    cms.CollectScheduleCode = DBAccessor.Instance.MaxUniqueNumber<DBObject.CollectSchedule>() + 1;
                    cms.RelationCode = rel.RelationCode;
                    cms.ItemTypeCode = cbxtype;
                    cms.ItemStateCode = cbxstate;
                    cms.ShopCode = cbxshop;
                    cms.CollectScheduleTime = dtpScheduleTime.Value.Date;
                    cms.CollectTime = cbCollected.Checked ? dtpCollectedTime.Value.Date : (DateTime?)null;
                    cms.InsertTime = DateTime.Now;
                    cms.UpdateTime = DateTime.Now;

                    DBAccessor.Instance.CollectSchedules =
                        DBAccessor.Instance.UpsertJson<CollectSchedule, DBObject.CollectSchedule>(cms);

                    MessageBox.Show(this, "登録しました", "ハードウェア管理");
                    OpenMalfunctionRegister(cms);
                    this.Visible = false;
                }
                else
                {
                    Relation.ReserveCode = Reserve?.ReserveCode;
                    Relation.MalfunctionCode = Malfunction?.MalfunctionCode;

                    DBAccessor.Instance.Relations =
                        DBAccessor.Instance.UpsertJson<Relation, DBObject.Relation>(Relation);

                    var cs = (from a in DBAccessor.Instance.CollectSchedules
                              where a.RelationCode == Relation.RelationCode
                              select a).FirstOrDefault();

                    cs.ItemTypeCode = cbxtype;
                    cs.ItemStateCode = cbxstate;
                    cs.ShopCode = cbxshop;
                    cs.CollectScheduleTime = dtpScheduleTime.Value.Date;
                    cs.CollectTime = cbCollected.Checked ? dtpCollectedTime.Value.Date : (DateTime?)null;
                    cs.UpdateTime = DateTime.Now;

                    DBAccessor.Instance.CollectSchedules =
                        DBAccessor.Instance.UpsertJson<CollectSchedule, DBObject.CollectSchedule>(cs);

                    MessageBox.Show(this, "登録しました", "ハードウェア管理");
                    OpenMalfunctionRegister(cs);
                    this.Visible = false;
                }
            }
        }

        private void FormCollectScheduleRegister_VisibleChanged(object sender, EventArgs e)
        {
            SetComboBoxes();

            if (Relation == null)
            {
                btnReserveSelect.Enabled = Reserve == null;
                btnMalfuinctionSelect.Enabled = Malfunction == null;

                if (Reserve != null)
                {
                    txtReserveCode.Text = Reserve.ReserveCode.ToString();
                    cbxType.SelectedValue = Reserve.ItemTypeCode;
                    cbxState.SelectedValue = Reserve.ItemStateCode;
                }

                if (Malfunction != null)
                {
                    txtMalfunctionCode.Text = Malfunction.MalfunctionCode.ToString();
                    cbxType.SelectedValue = Malfunction.ItemTypeCode;
                    cbxState.SelectedValue = Malfunction.ItemStateCode;
                }

                if (Reserve == null && Malfunction == null)
                {
                    txtReserveCode.Clear();
                    txtMalfunctionCode.Clear();
                    cbxType.SelectedValue = 0;
                    cbxState.SelectedValue = 0;
                }

                cbCollected.Checked = false;
                dtpCollectedTime.Enabled = false;
                dtpCollectedTime.Value = DateTime.Today;
            }
            else
            {
                var cs = (from a in DBAccessor.Instance.CollectSchedules
                          where a.RelationCode == Relation.RelationCode
                          select a).FirstOrDefault();

                txtReserveCode.Text = Relation.ReserveCode.ToString();
                txtMalfunctionCode.Text = Relation.MalfunctionCode.ToString();

                btnReserveSelect.Enabled = Relation.ReserveCode == null;
                btnMalfuinctionSelect.Enabled = Relation.MalfunctionCode == null;

                if (cs != null)
                {
                    cbxType.SelectedValue = cs.ItemTypeCode;
                    cbxState.SelectedValue = cs.ItemStateCode;
                    cbxShop.SelectedValue = cs.ShopCode;

                    if (cs.CollectTime == null)
                    {
                        cbCollected.Checked = false;
                        dtpCollectedTime.Enabled = false;
                        dtpCollectedTime.Value = DateTime.Today;
                    }
                    else
                    {
                        cbCollected.Checked = true;
                        dtpCollectedTime.Enabled = true;
                        dtpCollectedTime.Value = cs.CollectTime.Value;
                    }
                }
            }

            btnReserveClear.Enabled = Reserve != null;
            btnMalfunctionClear.Enabled = Malfunction != null;

            dtpScheduleTime.Value = DateTime.Today;
        }

        private void FormCollectScheduleRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void SetComboBoxes()
        {
            var list1 = new List<ItemType>();
            list1.Add(new ItemType() { ItemTypeCode = 0 });
            list1.AddRange(DBAccessor.Instance.ItemTypes);

            cbxType.DataSource = list1;


            var list2 = new List<ItemState>();
            list2.Add(new ItemState() { ItemStateCode = 0 });
            list2.AddRange(DBAccessor.Instance.ItemStates.Where(x => x.ApplyKbnValue.Enclose(ApplyKbns.CollectionState)));

            cbxState.DataSource = list2;


            var list3 = new List<ShopType>();
            list3.Add(new ShopType() { ShopCode = 0 });
            list3.AddRange(DBAccessor.Instance.ShopTypes.Where(x => x.Enable).OrderBy(x => x.ShopNum));

            cbxShop.DataSource = list3;
        }

        private void OpenMalfunctionRegister(CollectSchedule schedule)
        {
            if (schedule.CollectTime != null && Malfunction == null && MessageBox.Show(this, "回収完了しています。故障機を登録しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormMalfunctionRegister.Instance.Relation = DBAccessor.Instance.GetRelation(schedule);
                FormMalfunctionRegister.Instance.Show();
            }
        }

        public void SetResult(Reserve res)
        {
            Reserve = res;
            txtReserveCode.Text = Reserve.ReserveCode.ToString();
            btnReserveClear.Enabled = Reserve != null;
        }

        public void SetResult(Malfunction mal)
        {
            Malfunction = mal;
            txtMalfunctionCode.Text = Malfunction.MalfunctionCode.ToString();
            btnMalfunctionClear.Enabled = Malfunction != null;
        }
    }
}
