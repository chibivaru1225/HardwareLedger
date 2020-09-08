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
    public partial class FormMalfunctionRegister : Form
    {
        public Malfunction Malfunction { get; set; }

        public Relation Relation { get; set; }

        private static FormMalfunctionRegister instance;

        public static FormMalfunctionRegister Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormMalfunctionRegister();

                return instance;
            }
        }

        private FormMalfunctionRegister()
        {
            InitializeComponent();

            this.FormClosing += FormMalfunctionRegister_FormClosing;
            this.VisibleChanged += FormMalfunctionRegister_VisibleChanged;

            cbxType.ValueMember = nameof(ItemType.ItemTypeCode);
            cbxType.DisplayMember = nameof(ItemType.ItemTypeName);

            cbxState.ValueMember = nameof(ItemState.ItemStateCode);
            cbxState.DisplayMember = nameof(ItemState.StateName);

            cbxShop.ValueMember = nameof(ShopType.ShopCode);
            cbxShop.DisplayMember = nameof(ShopType.FullName);

            SetComboBoxes();

            this.btnRegist.Click += btnRegist_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (cbxType.SelectedValue is int ts && cbxShop.SelectedValue is int ss && cbxState.SelectedValue is int es)
            {
                Malfunction mar;

                if (ts == 0)
                {
                    MessageBox.Show(this, "種別を選択してください。", "ハードウェア管理");
                    return;
                }

                if (ss == 0)
                {
                    MessageBox.Show(this, "店舗を選択してください。", "ハードウェア管理");
                    return;
                }

                if (es == 0)
                {
                    MessageBox.Show(this, "状態を選択してください。", "ハードウェア管理");
                    return;
                }

                if (Malfunction == null)
                {
                    mar = new Malfunction();
                    mar.MalfunctionCode = DBAccessor.Instance.MaxUniqueNumber<DBObject.Malfunction>() + 1;
                    mar.InsertTime = DateTime.Now;
                }
                else
                {
                    mar = Malfunction;
                }

                mar.ShopCode = ss;
                mar.ItemTypeCode = ts;
                mar.ItemStateCode = es;
                mar.Name = txtItemName.Text;
                mar.UpdateTime = DateTime.Now;

                DBAccessor.Instance.Malfunctions = DBAccessor.Instance.UpsertJson<Malfunction, DBObject.Malfunction>(mar);

                if (Relation != null)
                {
                    Relation.MalfunctionCode = mar.MalfunctionCode;

                    DBAccessor.Instance.Relations = DBAccessor.Instance.UpsertJson<Relation, DBObject.Relation>(Relation);
                }

                MessageBox.Show(this, "登録しました", "ハードウェア管理");
                this.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void FormMalfunctionRegister_VisibleChanged(object sender, EventArgs e)
        {
            SetComboBoxes();
            Clear();
        }

        private void Clear()
        {
            cbxType.SelectedValue = 0;
            cbxState.SelectedValue = 0;
            cbxShop.SelectedValue = 0;
            txtItemName.Clear();
        }

        private void FormMalfunctionRegister_FormClosing(object sender, FormClosingEventArgs e)
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
            list2.AddRange(DBAccessor.Instance.ItemStates.Where(x => x.ApplyKbnValue.Enclose(ApplyKbns.Malfunction)));

            cbxState.DataSource = list2;


            var list3 = new List<ShopType>();
            list3.Add(new ShopType() { ShopCode = 0 });
            list3.AddRange(DBAccessor.Instance.ShopTypes.Where(x => x.Enable).OrderBy(x => x.ShopNum));

            cbxShop.DataSource = list3;
        }
    }
}
