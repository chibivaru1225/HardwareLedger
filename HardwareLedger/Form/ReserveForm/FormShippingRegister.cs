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
    public partial class FormShippingRegister : Form
    {
        private ReserveShipping ship;

        public Reserve Reserve { get; set; }

        private static FormShippingRegister instance;

        public static FormShippingRegister Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormShippingRegister();

                return instance;
            }
        }

        private FormShippingRegister()
        {
            InitializeComponent();

            cbxState.ValueMember = nameof(ItemState.ItemStateCode);
            cbxState.DisplayMember = nameof(ItemState.StateName);

            cbxShop.ValueMember = nameof(ShopType.ShopCode);
            cbxShop.DisplayMember = nameof(ShopType.FullName);

            SetComboBoxes();

            this.FormClosing += FormShippingRegister_FormClosing;
            this.VisibleChanged += FormShippingRegister_VisibleChanged;

            this.btnUpdate.Click += btnUpdate_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxShop.SelectedValue is int tcode && cbxState.SelectedValue is int scode)
            {
                if (MessageBox.Show(this, "保存しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ship == null)
                    {
                        ship = new ReserveShipping();
                        ship.ReserveShippingCode = DBAccessor.Instance.MaxUniqueNumber<DBObject.ReserveShipping>() + 1;
                        //ship.ReserveShippingCode = ct.Count() == 0 ? 1 : ct.Max(x => x.ReserveShippingCode) + 1;
                        ship.InsertTime = DateTime.Now;
                    }

                    ship.ReserveCode = Reserve.ReserveCode;
                    ship.ShopCode = tcode;
                    ship.State = scode;
                    ship.Biko = txtMemo.Text;
                    ship.ShippingTime = dtpShippingTime.Value;
                    ship.UpdateTime = DateTime.Now;

                    DBAccessor.Instance.ReserveShippings = DBAccessor.Instance.UpsertJson<ReserveShipping, DBObject.ReserveShipping>(ship);
                    MessageBox.Show(this, "登録しました", "ハードウェア管理");
                }
            }
        }


        private void FormShippingRegister_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Reserve != null)
            {
                txtReserveCode.Text = Reserve.ReserveCode.ToString();
                txtType.Text = DBAccessor.Instance.GetItemType(Reserve).ItemTypeName;
                txtReserveName.Text = Reserve.Name;
                txtModelNo.Text = Reserve.ModelNo;

                ship = (from a in DBAccessor.Instance.ReserveShippings
                        where a.ReserveCode == Reserve.ReserveCode
                        select a).FirstOrDefault();
            }

            if (ship == null)
            {
                cbxState.SelectedValue = 0;
                cbxShop.SelectedValue = 0;
                dtpShippingTime.Value = DateTime.Today;
                txtMemo.Clear();
            }
            else
            {
                cbxState.SelectedValue = ship.State;
                cbxShop.SelectedValue = ship.ShopCode;
                dtpShippingTime.Value = ship.ShippingTime;
                txtMemo.Text = ship.Biko;
            }
        }

        private void FormShippingRegister_FormClosing(object sender, FormClosingEventArgs e)
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
