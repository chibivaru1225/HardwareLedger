﻿namespace HardwareLedger
{
    partial class FormReserveList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReserveList));
            this.dgvReserveList = new System.Windows.Forms.DataGridView();
            this.chReserveCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chReserveType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chReserveName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chReserveState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCollectSchedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chReserveInsertTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chReserveUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserveList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReserveList
            // 
            this.dgvReserveList.AllowUserToAddRows = false;
            this.dgvReserveList.AllowUserToDeleteRows = false;
            this.dgvReserveList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReserveList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chReserveCode,
            this.chReserveType,
            this.chReserveName,
            this.chReserveState,
            this.chCollectSchedule,
            this.chReserveInsertTime,
            this.chReserveUpdateTime});
            this.dgvReserveList.Location = new System.Drawing.Point(9, 9);
            this.dgvReserveList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvReserveList.MultiSelect = false;
            this.dgvReserveList.Name = "dgvReserveList";
            this.dgvReserveList.ReadOnly = true;
            this.dgvReserveList.RowTemplate.Height = 21;
            this.dgvReserveList.Size = new System.Drawing.Size(986, 421);
            this.dgvReserveList.TabIndex = 0;
            // 
            // chReserveCode
            // 
            this.chReserveCode.HeaderText = "予備機コード";
            this.chReserveCode.Name = "chReserveCode";
            this.chReserveCode.ReadOnly = true;
            this.chReserveCode.Width = 120;
            // 
            // chReserveType
            // 
            this.chReserveType.HeaderText = "種別";
            this.chReserveType.Name = "chReserveType";
            this.chReserveType.ReadOnly = true;
            // 
            // chReserveName
            // 
            this.chReserveName.HeaderText = "名前";
            this.chReserveName.Name = "chReserveName";
            this.chReserveName.ReadOnly = true;
            this.chReserveName.Width = 200;
            // 
            // chReserveState
            // 
            this.chReserveState.HeaderText = "状態";
            this.chReserveState.Name = "chReserveState";
            this.chReserveState.ReadOnly = true;
            // 
            // chCollectSchedule
            // 
            this.chCollectSchedule.HeaderText = "回収予定";
            this.chCollectSchedule.Name = "chCollectSchedule";
            this.chCollectSchedule.ReadOnly = true;
            // 
            // chReserveInsertTime
            // 
            this.chReserveInsertTime.HeaderText = "登録日時";
            this.chReserveInsertTime.Name = "chReserveInsertTime";
            this.chReserveInsertTime.ReadOnly = true;
            this.chReserveInsertTime.Width = 150;
            // 
            // chReserveUpdateTime
            // 
            this.chReserveUpdateTime.HeaderText = "更新日時";
            this.chReserveUpdateTime.Name = "chReserveUpdateTime";
            this.chReserveUpdateTime.ReadOnly = true;
            this.chReserveUpdateTime.Width = 150;
            // 
            // FormReserveList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 439);
            this.Controls.Add(this.dgvReserveList);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReserveList";
            this.Text = "予備機一覧";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserveList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReserveList;
        private System.Windows.Forms.DataGridViewTextBoxColumn chReserveCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chReserveType;
        private System.Windows.Forms.DataGridViewTextBoxColumn chReserveName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chReserveState;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCollectSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn chReserveInsertTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn chReserveUpdateTime;
    }
}