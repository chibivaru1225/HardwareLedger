using System;
using System.Linq;
using System.Windows.Forms;
using static HardwareLedger.Enum;

namespace HardwareLedger
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();

            btnReserveRegister.Click += btnReserveRegister_Click;
            btnReserveList.Click += btnReserveList_Click;
            btnShippingList.Click += btnShippingList_Click;

            btnMalfunctionRegister.Click += btnMalfunctionRegister_Click;
            btnMalfunctionList.Click += btnMalfunctionList_Click;

            btnCollectScheduleAdd.Click += btnCollectScheduleAdd_Click;
            btnCollectScheduleList.Click += btnCollectScheduleList_Click;

            btnDataPrint.Click += btnDataPrint_Click;

            btnTypeMaster.Click += btnTypeMaster_Click;
            btnStateMaster.Click += btnStateMaster_Click;
            btnShopMaster.Click += btnShopMaster_Click;
        }

        private void btnDataPrint_Click(object sender, EventArgs e)
        {
            FormOutputExcel.Instance.Show();
        }

        private void btnShippingList_Click(object sender, EventArgs e)
        {
            FormShippingList.Instance.Show();
        }

        private void btnMalfunctionList_Click(object sender, EventArgs e)
        {
            FormMalfunctionList.Instance.Show();
        }

        private void btnMalfunctionRegister_Click(object sender, EventArgs e)
        {
            FormMalfunctionRegister.Instance.Relation = null;
            FormMalfunctionRegister.Instance.Malfunction = null;
            FormMalfunctionRegister.Instance.Show();
        }

        private void btnShopMaster_Click(object sender, EventArgs e)
        {
            FormShopMaster.Instance.Show();
        }

        private void btnTypeMaster_Click(object sender, EventArgs e)
        {
            FormTypeMaster.Instance.Show();
        }

        private void btnStateMaster_Click(object sender, EventArgs e)
        {
            FormStateMaster.Instance.Show();
        }

        private void btnCollectScheduleList_Click(object sender, EventArgs e)
        {
            FormCollectScheduleList.Instance.Show();
        }

        private void btnCollectScheduleAdd_Click(object sender, EventArgs e)
        {
            FormCollectScheduleRegister.Instance.Reserve = null;
            FormCollectScheduleRegister.Instance.Relation = null;
            FormCollectScheduleRegister.Instance.Malfunction = null;
            FormCollectScheduleRegister.Instance.Show();
        }

        private void btnReserveList_Click(object sender, EventArgs e)
        {
            FormReserveList.Instance.Show();
        }

        private void btnReserveRegister_Click(object sender, EventArgs e)
        {
            FormReserveRegister.Instance.Show();
        }
    }
}
