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
    public partial class FormShopMaster : Form
    {
        private BindingList<ShopTypeRow> shops;

        private ShopTypeRow shoprow;

        private static FormShopMaster instance;

        public static FormShopMaster Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormShopMaster();

                return instance;
            }
        }

        private FormShopMaster()
        {
            InitializeComponent();

            this.FormClosing += FormShopMaster_FormClosing;

            shops = new BindingList<ShopTypeRow>();

            dgvShopList.AutoGenerateColumns = false;
            dgvShopList.AllowUserToAddRows = false;

            btnRowAdd.Click += btnRowAdd_Click;
            btnRowSave.Click += btnRowSave_Click;

            dgvShopList.CurrentCellChanged += dgvShopList_CurrentCellChanged;

            SetColumnBindingName();
            SetDataGridView();
        }

        private void btnRowSave_Click(object sender, EventArgs e)
        {
            if (EditedDetail() == true && MessageBox.Show(this, "変更されています。保存しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                shoprow.Name = txtShopName.Text;
                shoprow.Num = txtShopNum.Text;
                shoprow.Enable = cbEnable.Checked;

                DBAccessor.Instance.ShopTypes =
                    DBAccessor.Instance.UpsertJson<ShopType, DBObject.ShopType>(shoprow);
                MessageBox.Show(this, "登録しました", "ハードウェア管理");
                SetDataGridView();
            }
        }

        private bool EditedDetail()
        {
            if (shoprow == null)
                return true;

            if (shoprow.Name != txtShopName.Text)
                return true;

            if (shoprow.Num != txtShopNum.Text)
                return true;

            if (shoprow.Enable != cbEnable.Checked)
                return true;

            return false;
        }

        private void btnRowAdd_Click(object sender, EventArgs e)
        {
            var shop = new ShopTypeRow();
            shop.Code = shops.Count() == 0 ? 1 : shops.Max(x => x.Code) + 1;
            shop.Enable = true;

            shops.Add(shop);
            SetDetail(shop);
            dgvShopList.FirstDisplayedScrollingRowIndex = dgvShopList.Rows.Count - 1;
            dgvShopList.CurrentCell = dgvShopList[0, dgvShopList.Rows.Count - 1];
        }

        private void SetDetail(ShopTypeRow row)
        {
            if (row != null)
            {
                shoprow = row;

                txtShopCode.Text = row.Code.ToString();
                txtShopNum.Text = row.Num;
                txtShopName.Text = row.Name;
                cbEnable.Checked = row.Enable;
            }
        }

        private void SetDataGridView()
        {
            shops.Clear();

            foreach (var row in DBAccessor.Instance.ShopTypes.OrderBy(x => x.ShopNum))
                shops.Add(row);

            dgvShopList.DataSource = shops;

            if (shops.Count() != 0)
            {
                dgvShopList.FirstDisplayedScrollingRowIndex = dgvShopList.Rows.Count - 1;
                dgvShopList.CurrentCell = dgvShopList[0, dgvShopList.Rows.Count - 1];
            }
        }

        private void SetColumnBindingName()
        {
            chListNum.DataPropertyName = nameof(ShopTypeRow.Num);
            chListName.DataPropertyName = nameof(ShopTypeRow.Name);
            chListRowState.DataPropertyName = nameof(ShopTypeRow.Enable);
        }

        private void dgvShopList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvShopList.CurrentRow != null)
                SetDetail(shops[dgvShopList.CurrentRow.Index]);
        }

        private void FormShopMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }
        private class ShopTypeRow
        {
            public int Code { get; set; }

            public String Num { get; set; }

            public String Name { get; set; }

            public bool Enable { get; set; }

            public static implicit operator ShopTypeRow(ShopType type)
            {
                var row = new ShopTypeRow();

                row.Code = type.ShopCode;
                row.Num = type.ShopNum;
                row.Name = type.ShopName;
                row.Enable = type.Enable;

                return row;
            }

            public static implicit operator ShopType(ShopTypeRow row)
            {
                var type = new ShopType();

                type.ShopCode = row.Code;
                type.ShopNum = row.Num;
                type.ShopName = row.Name;
                type.Enable = row.Enable;

                return type;
            }
        }
    }
}
