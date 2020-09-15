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
    public partial class FormShippingDetail : Form
    {
        public ReserveShipping Shipping { get; set; }

        private static FormShippingDetail instance;

        public static FormShippingDetail Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormShippingDetail();

                return instance;
            }
        }

        private FormShippingDetail()
        {
            InitializeComponent();

            cbxState.ValueMember = nameof(ItemState.ItemStateCode);
            cbxState.DisplayMember = nameof(ItemState.StateName);

            cbxShop.ValueMember = nameof(ShopType.ShopCode);
            cbxShop.DisplayMember = nameof(ShopType.FullName);

            SetComboBoxes();

            this.FormClosing += FormShippingDetail_FormClosing;
            this.VisibleChanged += FormShippingDetail_VisibleChanged;

            this.btnUpdate.Click += btnUpdate_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.btnDelete.Click += btnDelete_Click;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxShop.SelectedValue is int scode && cbxState.SelectedValue is int tcode)
            {
                var memo = txtMemo.Text;
                var time = dtpShippingTime.Value;

                if (memo != Shipping.Biko || 
                    scode != Shipping.ShopCode ||
                    tcode != Shipping.State || 
                    time != Shipping.ShippingTime)
                {
                    if (MessageBox.Show(this, "行が変更されています。保存しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Shipping.Biko = memo;
                        Shipping.ShippingTime = time;
                        Shipping.ShopCode = scode;
                        Shipping.State = tcode;
                        Shipping.UpdateTime = DateTime.Now;

                        DBAccessor.Instance.ReserveShippings = DBAccessor.Instance.UpsertJson<ReserveShipping, DBObject.ReserveShipping>(Shipping);
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
                DBAccessor.Instance.ReserveShippings = DBAccessor.Instance.RemoveJson<ReserveShipping, DBObject.ReserveShipping>(Shipping);

                MessageBox.Show(this, "削除しました", "ハードウェア管理");

                this.Visible = false;
            }
        }

        private void FormShippingDetail_VisibleChanged(object sender, EventArgs e)
        {
            if (Shipping == null)
            {
                cbxState.SelectedValue = 0;
                cbxShop.SelectedValue = 0;
                dtpShippingTime.Value = DateTime.Today;
                txtMemo.Clear();
            }
            else
            {
                var res = DBAccessor.Instance.GetReserve(Shipping);

                txtReserveCode.Text = res.ReserveCode.ToString();
                txtReserveName.Text = res.Name;
                txtModelNo.Text = res.ModelNo;
                txtType.Text = DBAccessor.Instance.GetItemType(res).ItemTypeName;

                cbxState.SelectedValue = Shipping.State;
                cbxShop.SelectedValue = Shipping.ShopCode;
                dtpShippingTime.Value = Shipping.ShippingTime;
                txtMemo.Text = Shipping.Biko;
            }
        }

        private void FormShippingDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void SetComboBoxes()
        {
            var list2 = new List<ItemState>();
            list2.Add(new ItemState() { ItemStateCode = 0 });
            list2.AddRange(DBAccessor.Instance.ItemStates.Where(x => x.ApplyKbnValue.Enclose(ApplyKbns.ShippingState)));

            cbxState.DataSource = list2;


            var list3 = new List<ShopType>();
            list3.Add(new ShopType() { ShopCode = 0 });
            list3.AddRange(DBAccessor.Instance.ShopTypes.Where(x => x.Enable).OrderBy(x => x.ShopNum));

            cbxShop.DataSource = list3;
        }
    }
}
