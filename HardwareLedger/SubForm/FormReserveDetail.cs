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
    public partial class FormReserveDetail : Form
    {
        private static FormReserveDetail instance;

        public Reserve ReserveDetail { private get; set; }

        public static FormReserveDetail Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormReserveDetail();

                return instance;
            }
        }

        private FormReserveDetail()
        {
            InitializeComponent();

            this.FormClosing += FormReserveDetail_FormClosing;
            this.VisibleChanged += FormReserveDetail_VisibleChanged;


            cbxType.ValueMember = nameof(ItemType.ItemTypeCode);
            cbxType.DisplayMember = nameof(ItemType.ItemTypeName);

            cbxState.ValueMember = nameof(ItemState.StateCode);
            cbxState.DisplayMember = nameof(ItemState.StateName);

            SetComboBoxes();
        }

        private void FormReserveDetail_VisibleChanged(object sender, EventArgs e)
        {
            if (ReserveDetail != null)
            {
                cbxType.SelectedValue = ReserveDetail.ItemTypeCode;
                cbxState.SelectedValue = ReserveDetail.StateCode;
                txtName.Text = ReserveDetail.Name;
            }
        }

        private void FormReserveDetail_FormClosing(object sender, FormClosingEventArgs e)
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
            list2.Add(new ItemState() { StateCode = 0 });
            list2.AddRange(DBAccessor.Instance.ItemStates.Where(x => x.ApplyKbn.Enclose(ApplyKbns.Reserve)));

            cbxState.DataSource = list2;
        }
    }
}
