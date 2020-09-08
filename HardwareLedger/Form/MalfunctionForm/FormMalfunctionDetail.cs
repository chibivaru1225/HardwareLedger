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
    public partial class FormMalfunctionDetail : Form
    {
        public Malfunction MalfunctionDetail { get; set; }

        private static FormMalfunctionDetail instance;

        public static FormMalfunctionDetail Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormMalfunctionDetail();

                return instance;
            }
        }

        private FormMalfunctionDetail()
        {
            InitializeComponent();

            this.FormClosing += FormMalfunctionDetail_FormClosing;
            this.Activated += FormMalfunctionDetail_Activated;
            this.VisibleChanged += FormMalfunctionDetail_VisibleChanged;

            cbxType.ValueMember = nameof(ItemType.ItemTypeCode);
            cbxType.DisplayMember = nameof(ItemType.ItemTypeName);

            cbxState.ValueMember = nameof(ItemState.ItemStateCode);
            cbxState.DisplayMember = nameof(ItemState.StateName);

            cbxShop.ValueMember = nameof(ShopType.ShopCode);
            cbxShop.DisplayMember = nameof(ShopType.FullName);

            SetComboBoxes();

            this.btnUpdate.Click += btnUpdate_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void FormMalfunctionDetail_VisibleChanged(object sender, EventArgs e)
        {
            SetComboBoxes();

            if (MalfunctionDetail != null)
            {
                cbxType.SelectedValue = MalfunctionDetail.ItemTypeCode;
                cbxState.SelectedValue = MalfunctionDetail.ItemStateCode;
                cbxShop.SelectedValue = MalfunctionDetail.ShopCode;
                txtName.Text = MalfunctionDetail.Name;
                txtInsertTime.Text = MalfunctionDetail.InsertTimeStr;
                txtUpdateTime.Text = MalfunctionDetail.UpdateTimeStr;
            }
            else
            {
                Clear();
            }
        }

        private void FormMalfunctionDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void FormMalfunctionDetail_Activated(object sender, EventArgs e)
        {
            if (MalfunctionDetail != null)
            {
                cbxType.SelectedValue = MalfunctionDetail.ItemTypeCode;
                cbxState.SelectedValue = MalfunctionDetail.ItemStateCode;
                cbxShop.SelectedValue = MalfunctionDetail.ShopCode;
                txtName.Text = MalfunctionDetail.Name;
                txtInsertTime.Text = MalfunctionDetail.InsertTimeStr;
                txtUpdateTime.Text = MalfunctionDetail.UpdateTimeStr;
            }
            else
            {
                Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxType.SelectedValue is int tcode && cbxState.SelectedValue is int scode && cbxShop.SelectedValue is int hcode)
            {
                var name = txtName.Text;

                if (tcode != MalfunctionDetail.ItemTypeCode ||
                    scode != MalfunctionDetail.ItemStateCode ||
                    name != MalfunctionDetail.Name || 
                    hcode != MalfunctionDetail.ShopCode)
                {
                    if (MessageBox.Show(this, "行が変更されています。保存しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MalfunctionDetail.ItemTypeCode = tcode;
                        MalfunctionDetail.ItemStateCode = scode;
                        MalfunctionDetail.ShopCode = hcode;
                        MalfunctionDetail.Name = name;
                        MalfunctionDetail.UpdateTime = DateTime.Now;

                        DBAccessor.Instance.Malfunctions = DBAccessor.Instance.UpsertJson<Malfunction, DBObject.Malfunction>(MalfunctionDetail);
                        MessageBox.Show(this, "登録しました", "ハードウェア管理");
                    }
                }
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
            list2.AddRange(DBAccessor.Instance.ItemStates.Where(x => x.ApplyKbnValue.Enclose(ApplyKbns.Malfunction)));

            cbxState.DataSource = list2;


            var list3 = new List<ShopType>();
            list3.Add(new ShopType() { ShopCode = 0 });
            list3.AddRange(DBAccessor.Instance.ShopTypes.Where(x => x.Enable).OrderBy(x => x.ShopNum));

            cbxShop.DataSource = list3;
        }

        private void Clear()
        {
            cbxType.SelectedValue = 0;
            cbxState.SelectedValue = 0;
            cbxShop.SelectedValue = 0;
            txtName.Text = String.Empty;
            txtInsertTime.Text = String.Empty;
            txtUpdateTime.Text = String.Empty;
        }
    }
}
