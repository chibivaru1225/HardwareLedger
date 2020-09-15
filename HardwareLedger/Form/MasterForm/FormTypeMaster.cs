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
    public partial class FormTypeMaster : Form
    {
        private BindingList<ItemTypeRow> types;

        private static FormTypeMaster instance;

        private ItemTypeRow typerow;

        public static FormTypeMaster Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormTypeMaster();

                return instance;
            }
        }

        private FormTypeMaster()
        {
            InitializeComponent();

            types = new BindingList<ItemTypeRow>();

            dgvTypeList.AutoGenerateColumns = false;
            dgvTypeList.AllowUserToAddRows = false;

            btnRowAdd.Click += btnRowAdd_Click;
            btnRowDelete.Click += btnRowDelete_Click;
            btnRowSave.Click += btnRowSave_Click;

            this.FormClosing += FormTypeMaster_FormClosing;
            this.VisibleChanged += FormTypeMaster_VisibleChanged;

            dgvTypeList.CurrentCellChanged += dgvTypeList_CurrentCellChanged;

            SetColumnBindingName();
            SetDataGridView();
        }

        private void FormTypeMaster_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void FormTypeMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void SetDataGridView()
        {
            types.Clear();

            foreach (var row in DBAccessor.Instance.ItemTypes)
                types.Add(row);

            dgvTypeList.DataSource = types;
        }

        private void SetColumnBindingName()
        {
            chListCode.DataPropertyName = nameof(ItemTypeRow.Code);
            chListName.DataPropertyName = nameof(ItemTypeRow.Name);
        }

        private void dgvTypeList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvTypeList.CurrentRow != null)
                SetDetail(types[dgvTypeList.CurrentRow.Index]);
        }

        private void btnRowAdd_Click(object sender, EventArgs e)
        {
            var type = new ItemTypeRow();
            type.Code = types.Count() == 0 ? 1 : types.Max(x => x.Code) + 1;

            types.Add(type);
            SetDetail(type);
            dgvTypeList.FirstDisplayedScrollingRowIndex = dgvTypeList.Rows.Count - 1;
            dgvTypeList.CurrentCell = dgvTypeList[0, dgvTypeList.Rows.Count - 1];
        }

        private void btnRowDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "削除すると戻せません。削除しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBAccessor.Instance.ItemTypes =
                    DBAccessor.Instance.RemoveJson<ItemType, DBObject.ItemType>(typerow);
                MessageBox.Show(this, "削除しました", "ハードウェア管理");
                SetDataGridView();
            }
        }

        private void btnRowSave_Click(object sender, EventArgs e)
        {
            if (EditedDetail() == true && MessageBox.Show(this, "変更されています。保存しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                typerow.Name = txtDetailName.Text;

                DBAccessor.Instance.ItemTypes =
                    DBAccessor.Instance.UpsertJson<ItemType, DBObject.ItemType>(typerow);
                MessageBox.Show(this, "登録しました", "ハードウェア管理");
                SetDataGridView();
            }
        }

        private void SetDetail(ItemTypeRow row)
        {
            if (row != null)
            {
                typerow = row;

                txtDetailName.Text = row.Name;
                txtDetailCode.Text = row.Code.ToString();
            }
        }

        private bool EditedDetail()
        {
            if (typerow == null)
                return true;

            if (typerow.Name != txtDetailName.Text)
                return true;

            return false;
        }

        private class ItemTypeRow
        {
            public int Code { get; set; }

            public String Name { get; set; }

            /// <summary>
            /// ItemType→ItemTypeRow変換
            /// </summary>
            /// <param name="type"></param>
            public static implicit operator ItemTypeRow(ItemType type)
            {
                var row = new ItemTypeRow();

                row.Code = type.ItemTypeCode;
                row.Name = type.ItemTypeName;

                return row;
            }

            /// <summary>
            /// ItemTypeRow→ItemType変換
            /// </summary>
            /// <param name="row"></param>
            public static implicit operator ItemType(ItemTypeRow row)
            {
                var type = new ItemType();

                type.ItemTypeCode = row.Code;
                type.ItemTypeName = row.Name;

                return type;
            }
        }
    }
}
