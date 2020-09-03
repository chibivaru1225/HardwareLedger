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
    public partial class FormStateMaster : Form
    {
        private BindingList<ItemStateRow> states;

        private ItemStateRow currentstaterow;

        private BindingList<ApplyRow> applies;

        private static FormStateMaster instance;

        public static FormStateMaster Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormStateMaster();

                return instance;
            }
        }

        private FormStateMaster()
        {
            InitializeComponent();

            states = new BindingList<ItemStateRow>();
            applies = new BindingList<ApplyRow>();

            dgvStateList.AutoGenerateColumns = false;
            dgvStateList.AllowUserToAddRows = false;

            dgvApplyKbnList.AutoGenerateColumns = false;
            dgvApplyKbnList.AllowUserToAddRows = false;

            this.FormClosing += FormStateMaster_FormClosing;
            this.VisibleChanged += FormStateMaster_VisibleChanged;

            btnDetailColor.Click += btnDetailColor_Click;
            btnRowAdd.Click += btnRowAdd_Click;
            btnRowDelete.Click += btnRowDelete_Click;
            btnRowSave.Click += btnRowSave_Click;

            dgvStateList.RowPrePaint += dgvStateList_RowPrePaint;
            dgvStateList.CurrentCellChanged += dgvStateList_CurrentCellChanged;

            SetColumnBindingName();
            SetDataGridView_dgvStateList();
        }

        private void btnRowSave_Click(object sender, EventArgs e)
        {
            this.dgvApplyKbnList.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (EditedDetail() == true && MessageBox.Show(this, "変更されています。保存しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                currentstaterow.Name = txtDetailName.Text;
                currentstaterow.RowColor = btnDetailColor.BackColor;
                currentstaterow.ApplyKbn = GetApplyKbnsForList();

                DBAccessor.Instance.ItemStates =
                    DBAccessor.Instance.UpsertJson<ItemState, DBObject.ItemState>(currentstaterow);
                MessageBox.Show(this, "登録しました", "ハードウェア管理");
                SetDataGridView_dgvStateList();
            }
        }

        private void dgvStateList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvStateList.CurrentRow != null)
                SetDetail(states[dgvStateList.CurrentRow.Index]);
        }

        private void dgvStateList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvStateList[nameof(chListColor), e.RowIndex].Style.BackColor = states[e.RowIndex].RowColor;
        }

        private void btnRowAdd_Click(object sender, EventArgs e)
        {
            var state = new ItemStateRow();
            state.StateCode = states.Count() == 0 ? 1 : states.Max(x => x.StateCode) + 1;
            state.ApplyKbn = ApplyKbns.NONE;

            states.Add(state);
            SetDetail(state);
            dgvStateList.FirstDisplayedScrollingRowIndex = dgvStateList.Rows.Count - 1;
            dgvStateList.CurrentCell = dgvStateList[0, dgvStateList.Rows.Count - 1];
        }

        private void btnRowDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "削除すると戻せません。削除しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBAccessor.Instance.ItemStates =
                    DBAccessor.Instance.RemoveJson<ItemState, DBObject.ItemState>(currentstaterow);
                MessageBox.Show(this, "削除しました", "ハードウェア管理");
                SetDataGridView_dgvStateList();
            }
        }

        private void btnDetailColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = btnDetailColor.BackColor;
            cd.AllowFullOpen = true;
            cd.SolidColorOnly = false;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnDetailColor.BackColor = cd.Color;
            }
        }

        private void FormStateMaster_VisibleChanged(object sender, EventArgs e)
        {
        }

        //private void FormStateMaster_Activated(object sender, EventArgs e)
        //{
        //    SetDataGridView_dgvStateList();
        //}

        private void FormStateMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void SetColumnBindingName()
        {
            chListCode.DataPropertyName = nameof(ItemStateRow.StateCode);
            chListName.DataPropertyName = nameof(ItemStateRow.Name);
            chListApplyKbn.DataPropertyName = nameof(ItemStateRow.ApplyKbnStr);

            chDetailIsApply.DataPropertyName = nameof(ApplyRow.IsEnable);
            chDetailApplyKbns.DataPropertyName = nameof(ApplyRow.Name);
        }

        private void SetDataGridView_dgvStateList()
        {
            states.Clear();

            foreach (var row in DBAccessor.Instance.ItemStates)
                states.Add(row);

            dgvStateList.DataSource = states;
        }

        private void SetDataGridView_dgvApplyKbnList(ApplyKbn kbn = null)
        {
            applies.Clear();

            foreach (var k in System.Enum.GetValues(typeof(ApplyKbns)))
            {
                if (k is ApplyKbns type && type != ApplyKbns.NONE)
                {
                    var item = new ApplyRow();
                    item.Kbns = type;
                    item.IsEnable = kbn == null ? false : kbn.Enclose(type);

                    applies.Add(item);
                }
            }

            dgvApplyKbnList.DataSource = applies;
        }

        private void SetDetail(ItemStateRow row)
        {
            DetailClear();

            if (row != null)
            {
                currentstaterow = row;

                txtDetailName.Text = row.Name;
                txtDetailCode.Text = row.StateCode.ToString();

                btnDetailColor.BackColor = row.RowColor;

                SetDataGridView_dgvApplyKbnList(row.ApplyKbn);
            }
        }

        private ApplyKbns GetApplyKbnsForList()
        {
            ApplyKbns kbns = ApplyKbns.NONE;

            foreach (var row in applies)
            {
                if (row.IsEnable)
                    kbns |= row.Kbns;
            }

            return kbns;
        }

        private bool EqualApplyKbn(ApplyKbns akbn)
        {
            return akbn == GetApplyKbnsForList();
        }

        private bool EditedDetail()
        {
            if (currentstaterow == null)
                return true;

            if (currentstaterow.Name != txtDetailName.Text)
                return true;

            if (currentstaterow.RowColor != btnDetailColor.BackColor)
                return true;

            if (EqualApplyKbn(currentstaterow.ApplyKbn) == false)
                return true;

            return false;
        }

        private void DetailClear()
        {
            txtDetailName.Clear();
            txtDetailCode.Clear();
            SetDataGridView_dgvApplyKbnList();
            btnDetailColor.BackColor = Color.White;
        }

        private class ItemStateRow
        {
            public int StateCode { get; set; }

            public String Name { get; set; }

            public ApplyKbn ApplyKbn { get; set; }

            public String ApplyKbnStr => ApplySubKbn.GetApplyKbnState(ApplyKbn.Value).ViewValue;

            public Color RowColor { get; set; }

            public static implicit operator ItemStateRow(ItemState res)
            {
                var row = new ItemStateRow();

                row.StateCode = res.ItemStateCode;
                row.Name = res.StateName;
                row.ApplyKbn = res.ApplyKbnValue;
                row.RowColor = res.StateColorValue;

                return row;
            }

            public static implicit operator ItemState(ItemStateRow row)
            {
                var res = new ItemState();

                res.ItemStateCode = row.StateCode;
                res.StateName = row.Name;
                res.ApplyKbnValue = row.ApplyKbn;
                res.StateColorValue = row.RowColor;

                return res;
            }
        }

        private class ApplyRow
        {
            public bool IsEnable { get; set; }

            public int Code { get; set; }

            public String Name => Kbn.ViewValue;

            public ApplyKbns Kbns { get; set; }

            public ApplyKbn Kbn => new ApplyKbn(Kbns);
        }
    }
}
