using HardwareLedger.DBObject;
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

namespace HardwareLedger.SubForm
{
    public partial class FormCollectScheduleRegister : Form
    {
        public Reserve Reserve { get; set; }

        public Malfunction Malfunction { get; set; }

        public Relation Relation { get; set; }


        private static FormCollectScheduleRegister instance;

        public static FormCollectScheduleRegister Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormCollectScheduleRegister();

                return instance;
            }
        }

        private FormCollectScheduleRegister()
        {
            InitializeComponent();

            this.FormClosing += FormCollectScheduleRegister_FormClosing;
            this.VisibleChanged += FormCollectScheduleRegister_VisibleChanged;

            this.btnUpdate.Click += btnUpdate_Click;
            this.btnCancel.Click += btnCancel_Click;

            cbxType.ValueMember = nameof(ItemType.ItemTypeCode);
            cbxType.DisplayMember = nameof(ItemType.ItemTypeName);

            cbxState.ValueMember = nameof(ItemState.StateCode);
            cbxState.DisplayMember = nameof(ItemState.StateName);

            SetComboBoxes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxType.SelectedValue is int cbxtype && cbxState.SelectedValue is int cbxstate)
            {
                if (Relation == null)
                {
                    var rels = DBAccessor.Instance.ReadJson<Relation, DBObject.Relation>();

                    var rel = new Relation();
                    rel.RelationCode = rels.Count() == 0 ? 1 : rels.Max(x => x.RelationCode) + 1;

                    if (Reserve != null)
                        rel.ReserveCode = Reserve.ReserveCode;
                    else
                        rel.ReserveCode = null;

                    if (Malfunction != null)
                        rel.MalfunctionCode = Malfunction.MalfunctionCode;
                    else
                    {
                        var mals = DBAccessor.Instance.ReadJson<Malfunction, DBObject.Malfunction>();

                        var mal = new Malfunction();
                        mal.MalfunctionCode = mals.Count() == 0 ? 1 : mals.Max(x => x.MalfunctionCode) + 1;
                        mal.ItemTypeCode = cbxtype;
                        mal.StateCode = cbxstate;
                        mal.Name = String.Empty;
                        mal.InsertTime = DateTime.Now;
                        mal.UpdateTime = DateTime.Now;

                        DBAccessor.Instance.UpsertJson<Malfunction, DBObject.Malfunction>(mal);

                        rel.MalfunctionCode = mal.MalfunctionCode;
                    }

                    DBAccessor.Instance.UpsertJson<Relation, DBObject.Relation>(rel);

                    MessageBox.Show(this, "登録しました", "ハードウェア管理");
                    Clear();
                }
                else
                {

                }
            }
        }

        private void FormCollectScheduleRegister_VisibleChanged(object sender, EventArgs e)
        {
            if (Reserve != null)
            {
                txtReserveCode.Text = Reserve.ReserveCode.ToString();
                cbxState.SelectedValue = Reserve.StateCode;
            }
            if (Malfunction != null)
            {
                txtMalfunctionCode.Text = Malfunction.MalfunctionCode.ToString();
                cbxState.SelectedValue = Malfunction.StateCode;
            }

            dtpScheduleTime.Value = DateTime.Today;
        }

        private void FormCollectScheduleRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
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
            list2.Add(new ItemState() { StateCode = 0 });
            list2.AddRange(DBAccessor.Instance.ItemStates.Where(x => x.ApplyKbnValue.Enclose(ApplyKbns.Malfunction)));

            cbxState.DataSource = list2;
        }

        private void Clear()
        {

        }
    }
}
