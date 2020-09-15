using System;
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
    public partial class FormReserveDetail : Form
    {
        private static FormReserveDetail instance;

        public Reserve ReserveDetail { private get; set; }

        public static FormReserveDetail Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormReserveDetail();

                return instance;
            }
        }

        private FormReserveDetail()
        {
            InitializeComponent();

            this.FormClosing += FormReserveDetail_FormClosing;
            this.Activated += FormReserveDetail_Activated;
            this.VisibleChanged += FormReserveDetail_VisibleChanged;

            cbxType.ValueMember = nameof(ItemType.ItemTypeCode);
            cbxType.DisplayMember = nameof(ItemType.ItemTypeName);

            cbxState.ValueMember = nameof(ItemState.ItemStateCode);
            cbxState.DisplayMember = nameof(ItemState.StateName);

            cbxZaiko.ValueMember = nameof(ZaikoRow.Value);
            cbxZaiko.DisplayMember = nameof(ZaikoRow.ViewValue);

            SetComboBoxes();

            this.btnCollectRegist.Click += btnCollectRegist_Click;
            this.btnShipping.Click += btnShipping_Click;
            this.btnUpdate.Click += btnUpdate_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnReprint.Click += btnReprint_Click;
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "ラベルを再印刷しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var form = new FormReportTest(ReserveDetail);
                form.Show();
            }
        }

        private void btnShipping_Click(object sender, EventArgs e)
        {
            FormShippingRegister.Instance.Reserve = this.ReserveDetail;
            FormShippingRegister.Instance.Show();
        }

        private void FormReserveDetail_Activated(object sender, EventArgs e)
        {
            if (ReserveDetail != null)
            {
                cbxType.SelectedValue = ReserveDetail.ItemTypeCode;
                cbxState.SelectedValue = ReserveDetail.ItemStateCode;
                cbxZaiko.SelectedValue = ReserveDetail.Zaiko.Value;
                txtName.Text = ReserveDetail.Name;
                txtModelNo.Text = ReserveDetail.ModelNo;
                txtInsertTime.Text = ReserveDetail.InsertTimeStr;
                txtUpdateTime.Text = ReserveDetail.UpdateTimeStr;

                var cs = new CollectState(ReserveDetail);
                txtCollectSchedule.Text = cs.ViewValue;
                btnCSCheck.Enabled = cs.Value != CollectStates.Undecided;

                var ss = new ShippingState(ReserveDetail);
                txtShipping.Text = ss.ViewValue;
            }
            else
            {
                Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxType.SelectedValue is int tcode && cbxState.SelectedValue is int scode && cbxZaiko.SelectedValue is ZaikoTypes zt)
            {
                var name = txtName.Text;
                var modelno = txtModelNo.Text;

                if (tcode != ReserveDetail.ItemTypeCode ||
                    scode != ReserveDetail.ItemStateCode ||
                    name != ReserveDetail.Name ||
                    modelno != ReserveDetail.ModelNo ||
                    zt != ReserveDetail.Zaiko)
                {
                    if (MessageBox.Show(this, "行が変更されています。保存しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ReserveDetail.ItemTypeCode = tcode;
                        ReserveDetail.ItemStateCode = scode;
                        ReserveDetail.Name = name;
                        ReserveDetail.ModelNo = modelno;
                        ReserveDetail.UpdateTime = DateTime.Now;
                        ReserveDetail.Zaiko = zt;

                        DBAccessor.Instance.Reserves = DBAccessor.Instance.UpsertJson<Reserve, DBObject.Reserve>(ReserveDetail);
                        MessageBox.Show(this, "登録しました", "ハードウェア管理");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "削除しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var rel = DBAccessor.Instance.GetRelation(ReserveDetail);

                if (rel != null)
                {
                    rel.MalfunctionCode = null;
                    DBAccessor.Instance.Relations = DBAccessor.Instance.UpsertJson<Relation, DBObject.Relation>(rel);
                }

                var shi = DBAccessor.Instance.GetShipping(ReserveDetail);

                if (shi != null)
                {
                    DBAccessor.Instance.ReserveShippings = DBAccessor.Instance.RemoveJson<ReserveShipping, DBObject.ReserveShipping>(shi);
                }

                DBAccessor.Instance.Reserves = DBAccessor.Instance.RemoveJson<Reserve, DBObject.Reserve>(ReserveDetail);

                MessageBox.Show(this, "削除しました", "ハードウェア管理");

                this.Visible = false;
            }
        }

        private void btnCollectRegist_Click(object sender, EventArgs e)
        {
            FormCollectScheduleRegister.Instance.Reserve = ReserveDetail;
            FormCollectScheduleRegister.Instance.Relation = (from a in DBAccessor.Instance.Relations
                                                             where a.ReserveCode == ReserveDetail.ReserveCode
                                                             select a).FirstOrDefault();

            var cs = DBAccessor.Instance.GetCollectSchedule(ReserveDetail);

            if (cs == null || MessageBox.Show(this, "回収予定が登録済ですが、変更しますか？", "ハードウェア管理", MessageBoxButtons.OKCancel) == DialogResult.OK)
                FormCollectScheduleRegister.Instance.Show();
        }

        private void FormReserveDetail_VisibleChanged(object sender, EventArgs e)
        {
            SetComboBoxes();

            if (ReserveDetail != null)
            {
                cbxType.SelectedValue = ReserveDetail.ItemTypeCode;
                cbxState.SelectedValue = ReserveDetail.ItemStateCode;
                cbxZaiko.SelectedValue = ReserveDetail.Zaiko.Value;
                txtName.Text = ReserveDetail.Name;
                txtModelNo.Text = ReserveDetail.ModelNo;
                txtInsertTime.Text = ReserveDetail.InsertTimeStr;
                txtUpdateTime.Text = ReserveDetail.UpdateTimeStr;

                var cs = new CollectState(ReserveDetail);

                txtCollectSchedule.Text = cs.ViewValue;
                btnCSCheck.Enabled = cs.Value != CollectStates.Undecided;
            }
            else
            {
                Clear();
            }
        }

        private void FormReserveDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void SetComboBoxes()
        {
            var list1 = new List<ItemType>();
            list1.Add(new ItemType() { ItemTypeCode = 0 });
            list1.AddRange(DBAccessor.Instance.ItemTypes);

            cbxType.DataSource = list1;


            var list2 = new List<ItemState>();
            list2.Add(new ItemState() { ItemStateCode = 0 });
            list2.AddRange(DBAccessor.Instance.ItemStates.Where(x => x.ApplyKbnValue.Enclose(ApplyKbns.Reserve)));

            cbxState.DataSource = list2;


            var list4 = new List<ZaikoRow>();
            list4.Clear();

            foreach (var etype in System.Enum.GetValues(typeof(ZaikoTypes)))
            {
                if (etype is ZaikoTypes type && type != ZaikoTypes.NONE)
                {
                    var item = new ZaikoRow();
                    item.ZaikoType = type;

                    list4.Add(item);
                }
            }

            cbxZaiko.DataSource = list4;
            cbxZaiko.SelectedValue = ZaikoTypes.HiZaiko;
        }

        private void Clear()
        {
            cbxType.SelectedValue = 0;
            cbxState.SelectedValue = 0;
            cbxZaiko.SelectedValue = ZaikoTypes.HiZaiko;
            txtName.Clear();
            txtModelNo.Clear();
            txtInsertTime.Text = String.Empty;
            txtUpdateTime.Text = String.Empty;
            txtCollectSchedule.Text = CollectState.GetViewValue(CollectStates.Undecided);
            btnCSCheck.Enabled = false;
        }

        private class ZaikoRow
        {
            public ZaikoType ZaikoType { get; set; }

            public string ViewValue => ZaikoType.ViewValue;

            public ZaikoTypes Value => ZaikoType.Value;
        }
    }
}
