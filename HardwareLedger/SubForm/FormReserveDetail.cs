﻿using System;
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
            this.Activated += FormReserveDetail_Activated;
            this.VisibleChanged += FormReserveDetail_VisibleChanged;

            cbxType.ValueMember = nameof(ItemType.ItemTypeCode);
            cbxType.DisplayMember = nameof(ItemType.ItemTypeName);

            cbxState.ValueMember = nameof(ItemState.ItemStateCode);
            cbxState.DisplayMember = nameof(ItemState.StateName);

            SetComboBoxes();

            this.btnCollectRegist.Click += btnCollectRegist_Click;
            this.btnUpdate.Click += btnUpdate_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void FormReserveDetail_Activated(object sender, EventArgs e)
        {
            if (ReserveDetail != null)
            {
                cbxType.SelectedValue = ReserveDetail.ItemTypeCode;
                cbxState.SelectedValue = ReserveDetail.ItemStateCode;
                txtName.Text = ReserveDetail.Name;
                txtInsertTime.Text = ReserveDetail.InsertTimeStr;
                txtUpdateTime.Text = ReserveDetail.UpdateTimeStr;

                //var cs = DBAccessor.Instance.GetCollectSchedule(ReserveDetail);
                var cs = new CollectState(ReserveDetail);

                txtCollectSchedule.Text = cs.ViewValue;
                btnCSCheck.Enabled = cs.Value != CollectStates.Undecided;
            }
            else
            {
                Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxType.SelectedValue is int tcode && cbxState.SelectedValue is int scode)
            {
                var name = txtName.Text;

                if (tcode != ReserveDetail.ItemTypeCode ||
                    scode != ReserveDetail.ItemStateCode ||
                    name != ReserveDetail.Name)
                {
                    if (MessageBox.Show(this, "行が変更されています。保存しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ReserveDetail.ItemTypeCode = tcode;
                        ReserveDetail.ItemStateCode = scode;
                        ReserveDetail.Name = name;
                        ReserveDetail.UpdateTime = DateTime.Now;

                        DBAccessor.Instance.Reserves = DBAccessor.Instance.UpsertJson<Reserve, DBObject.Reserve>(ReserveDetail);
                        MessageBox.Show(this, "登録しました", "ハードウェア管理");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnCollectRegist_Click(object sender, EventArgs e)
        {
            FormCollectScheduleRegister.Instance.Reserve = ReserveDetail;
            FormCollectScheduleRegister.Instance.Relation = (from a in DBAccessor.Instance.Relations
                                                             where a.ReserveCode == ReserveDetail.ReserveCode
                                                             select a).FirstOrDefault();

            var cs = DBAccessor.Instance.GetCollectSchedule(ReserveDetail);

            if (cs == null || MessageBox.Show(this, "回収予定が登録済ですが、変更しますか？", "ハードウェア管理", MessageBoxButtons.OKCancel) == DialogResult.OK)
                FormCollectScheduleRegister.Instance.Show();
        }

        private void FormReserveDetail_VisibleChanged(object sender, EventArgs e)
        {
            if (ReserveDetail != null)
            {
                cbxType.SelectedValue = ReserveDetail.ItemTypeCode;
                cbxState.SelectedValue = ReserveDetail.ItemStateCode;
                txtName.Text = ReserveDetail.Name;
                txtInsertTime.Text = ReserveDetail.InsertTimeStr;
                txtUpdateTime.Text = ReserveDetail.UpdateTimeStr;

                var cs = new CollectState(ReserveDetail);

                txtCollectSchedule.Text = cs.ViewValue;
                btnCSCheck.Enabled = cs.Value != CollectStates.Undecided;
            }
            else
            {
                Clear();
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
            list2.Add(new ItemState() { ItemStateCode = 0 });
            list2.AddRange(DBAccessor.Instance.ItemStates.Where(x => x.ApplyKbnValue.Enclose(ApplyKbns.Reserve)));

            cbxState.DataSource = list2;
        }

        private void Clear()
        {
            cbxType.SelectedValue = 0;
            cbxState.SelectedValue = 0;
            txtName.Text = String.Empty;
            txtInsertTime.Text = String.Empty;
            txtUpdateTime.Text = String.Empty;
            txtCollectSchedule.Text = CollectState.GetViewValue(CollectStates.Undecided);
            btnCSCheck.Enabled = false;
        }
    }
}
