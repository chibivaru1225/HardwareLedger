﻿using HardwareLedger.DBObject;
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

            cbxState.ValueMember = nameof(ItemState.ItemStateCode);
            cbxState.DisplayMember = nameof(ItemState.StateName);

            cbxShop.ValueMember = nameof(ShopType.ShopCode);
            cbxShop.DisplayMember = nameof(ShopType.FullName);

            cbCollected.CheckedChanged += cbCollected_CheckedChanged;

            SetComboBoxes();
        }

        private void cbCollected_CheckedChanged(object sender, EventArgs e)
        {
            dtpCollectedTime.Enabled = cbCollected.Checked;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxType.SelectedValue is int cbxtype && cbxState.SelectedValue is int cbxstate && cbxShop.SelectedValue is int cbxshop)
            {
                if (cbxshop == 0)
                {
                    MessageBox.Show(this, "店舗は必ず選択してください。", "ハードウェア管理");
                    return;
                }

                if (Relation == null)
                {
                    var rels = DBAccessor.Instance.Relations;

                    var rel = new Relation();
                    rel.RelationCode = rels.Count() == 0 ? 1 : rels.Max(x => x.RelationCode) + 1;
                    rel.ReserveCode = Reserve?.ReserveCode;
                    rel.MalfunctionCode = Malfunction?.MalfunctionCode;

                    DBAccessor.Instance.Relations = DBAccessor.Instance.UpsertJson<Relation, DBObject.Relation>(rel);

                    Relation = rel;

                    var cms = new CollectSchedule();
                    cms.CollectScheduleCode = DBAccessor.Instance.CollectSchedules.Count() == 0 ?
                        1 : DBAccessor.Instance.CollectSchedules.Max(x => x.CollectScheduleCode) + 1;
                    cms.RelationCode = rel.RelationCode;
                    cms.ItemTypeCode = cbxtype;
                    cms.ItemStateCode = cbxstate;
                    cms.ShopCode = cbxshop;
                    cms.CollectScheduleTime = dtpScheduleTime.Value.Date;
                    cms.CollectTime = cbCollected.Checked ? dtpCollectedTime.Value.Date : (DateTime?)null;
                    cms.InsertTime = DateTime.Now;
                    cms.UpdateTime = DateTime.Now;

                    DBAccessor.Instance.CollectSchedules =
                        DBAccessor.Instance.UpsertJson<CollectSchedule, DBObject.CollectSchedule>(cms);

                    MessageBox.Show(this, "登録しました", "ハードウェア管理");
                    OpenMalfunctionRegister(cms);
                    this.Visible = false;
                }
                else
                {
                    var cs = (from a in DBAccessor.Instance.CollectSchedules
                              where a.RelationCode == Relation.RelationCode
                              select a).FirstOrDefault();

                    cs.ItemTypeCode = cbxtype;
                    cs.ItemStateCode = cbxstate;
                    cs.ShopCode = cbxshop;
                    cs.CollectScheduleTime = dtpScheduleTime.Value.Date;
                    cs.CollectTime = cbCollected.Checked ? dtpCollectedTime.Value.Date : (DateTime?)null;
                    cs.UpdateTime = DateTime.Now;

                    DBAccessor.Instance.CollectSchedules =
                        DBAccessor.Instance.UpsertJson<CollectSchedule, DBObject.CollectSchedule>(cs);

                    MessageBox.Show(this, "登録しました", "ハードウェア管理");
                    OpenMalfunctionRegister(cs);
                    this.Visible = false;
                }
            }
        }

        private void FormCollectScheduleRegister_VisibleChanged(object sender, EventArgs e)
        {
            if (Relation == null)
            {
                if (Reserve != null)
                {
                    txtReserveCode.Text = Reserve.ReserveCode.ToString();
                    cbxType.SelectedValue = Reserve.ItemTypeCode;
                    cbxState.SelectedValue = Reserve.ItemStateCode;
                }

                if (Malfunction != null)
                {
                    txtMalfunctionCode.Text = Malfunction.MalfunctionCode.ToString();
                    cbxType.SelectedValue = Malfunction.ItemTypeCode;
                    cbxState.SelectedValue = Malfunction.ItemStateCode;
                }

                cbCollected.Checked = false;
                dtpCollectedTime.Enabled = false;
                dtpCollectedTime.Value = DateTime.Today;
            }
            else
            {
                txtReserveCode.Text = Relation.ReserveCode.ToString();
                txtMalfunctionCode.Text = Relation.MalfunctionCode.ToString();

                var cs = (from a in DBAccessor.Instance.CollectSchedules
                          where a.RelationCode == Relation.RelationCode
                          select a).FirstOrDefault();

                if (cs != null)
                {
                    cbxType.SelectedValue = cs.ItemTypeCode;
                    cbxState.SelectedValue = cs.ItemStateCode;
                    cbxShop.SelectedValue = cs.ShopCode;

                    if (cs.CollectTime == null)
                    {
                        cbCollected.Checked = false;
                        dtpCollectedTime.Enabled = false;
                        dtpCollectedTime.Value = DateTime.Today;
                    }
                    else
                    {
                        cbCollected.Checked = true;
                        dtpCollectedTime.Enabled = true;
                        dtpCollectedTime.Value = cs.CollectTime.Value;
                    }
                }
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
            list2.Add(new ItemState() { ItemStateCode = 0 });
            list2.AddRange(DBAccessor.Instance.ItemStates.Where(x => x.ApplyKbnValue.Enclose(ApplyKbns.CollectionState)));

            cbxState.DataSource = list2;


            var list3 = new List<ShopType>();
            list3.Add(new ShopType() { ShopCode = 0 });
            list3.AddRange(DBAccessor.Instance.ShopTypes.Where(x => x.Enable).OrderBy(x => x.ShopNum));

            cbxShop.DataSource = list3;
        }

        private void OpenMalfunctionRegister(CollectSchedule schedule)
        {
            if (schedule.CollectTime != null && MessageBox.Show(this, "回収完了しています。故障機を登録しますか？", "ハードウェア管理", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormMalfunctionRegister.Instance.Relation = DBAccessor.Instance.GetRelation(schedule);
                FormMalfunctionRegister.Instance.Show();
            }
        }
    }
}
