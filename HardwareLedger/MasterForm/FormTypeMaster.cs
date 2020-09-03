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
        }

        private void btnRowSave_Click(object sender, EventArgs e)
        {
        }

        private void SetDetail(ItemTypeRow row)
        {
        }

        private class ItemTypeRow
        {
            public int Code { get; set; }

            public String Name { get; set; }

            public static implicit operator ItemTypeRow(ItemType type)
            {
                var row = new ItemTypeRow();

                row.Code = type.ItemTypeCode;
                row.Name = type.ItemTypeName;

                return row;
            }

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
