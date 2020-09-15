using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public partial class FormReserveRegister : Form
    {
        private static FormReserveRegister instance;

        public static FormReserveRegister Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormReserveRegister();

                return instance;
            }
        }

        private FormReserveRegister()
        {
            InitializeComponent();

            cbxItemType.ValueMember = nameof(ItemType.ItemTypeCode);
            cbxItemType.DisplayMember = nameof(ItemType.ItemTypeName);

            cbxItemState.ValueMember = nameof(ItemState.ItemStateCode);
            cbxItemState.DisplayMember = nameof(ItemState.StateName);

            cbxZaiko.ValueMember = nameof(ZaikoRow.Value);
            cbxZaiko.DisplayMember = nameof(ZaikoRow.ViewValue);

            SetComboBoxes();

            btnRegist.Click += btnRegist_Click;
            btnCancel.Click += btnCancel_Click;

            this.Shown += FormReserveRegister_Shown;
            this.FormClosing += FormReserveRegister_FormClosing;
            this.VisibleChanged += FormReserveRegister_VisibleChanged;
        }

        private void FormReserveRegister_Shown(object sender, EventArgs e)
        {
            Clear();
        }

        private void FormReserveRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void FormReserveRegister_VisibleChanged(object sender, EventArgs e)
        {
            Clear();
            SetComboBoxes();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtItemName.Text.Trim()) == true)
            {
                MessageBox.Show(this, "ハードウェア名を入力してください", "ハードウェア管理");
                return;
            }

            if (cbxItemType.SelectedValue is int itc && cbxItemState.SelectedValue is int sc && cbxZaiko.SelectedValue is ZaikoTypes zt)
            {
                var rs = DBAccessor.Instance.Reserves;

                var res = new Reserve();

                res.ReserveCode = rs.Count() == 0 ? 1 : rs.Max(x => x.ReserveCode) + 1;
                res.Name = txtItemName.Text.Trim();
                res.ModelNo = txtModelNo.Text.Trim();
                res.InsertTime = DateTime.Now;
                res.UpdateTime = DateTime.Now;
                res.ItemTypeCode = itc;
                res.ItemStateCode = sc;
                res.Zaiko = zt;
                
                DBAccessor.Instance.Reserves = DBAccessor.Instance.UpsertJson<Reserve, DBObject.Reserve>(res);

                MessageBox.Show(this, "登録しました", "ハードウェア管理");
                Clear();

                var form = new FormReportTest(res);
                form.Show();
            }
        }

        private void Clear()
        {
            cbxItemType.SelectedValue = 0;
            cbxItemState.SelectedValue = 0;
            cbxZaiko.SelectedValue = ZaikoTypes.HiZaiko;
            txtItemName.Clear();
            txtModelNo.Clear();
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

            cbxItemType.DataSource = list1;


            var list2 = new List<ItemState>();
            list2.Add(new ItemState() { ItemStateCode = 0 });
            list2.AddRange(DBAccessor.Instance.ItemStates.Where(x => x.ApplyKbnValue.Enclose(ApplyKbns.Reserve)));

            cbxItemState.DataSource = list2;


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

        private class ZaikoRow
        {
            public ZaikoType ZaikoType { get; set; }

            public string ViewValue => ZaikoType.ViewValue;

            public ZaikoTypes Value => ZaikoType.Value;
        }
    }
}
