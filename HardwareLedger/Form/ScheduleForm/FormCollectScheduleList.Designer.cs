namespace HardwareLedger
{
    partial class FormCollectScheduleList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCollectScheduleList));
            this.dgvCollectScheduleList = new System.Windows.Forms.DataGridView();
            this.chReserveCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chMalfunctionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chItemState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chShop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCollectScheduleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCollectDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chInsertTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollectScheduleList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCollectScheduleList
            // 
            this.dgvCollectScheduleList.AllowUserToAddRows = false;
            this.dgvCollectScheduleList.AllowUserToDeleteRows = false;
            this.dgvCollectScheduleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCollectScheduleList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chReserveCode,
            this.chMalfunctionCode,
            this.chItemType,
            this.chItemState,
            this.chShop,
            this.chCollectScheduleDate,
            this.chCollectDate,
            this.chInsertTime,
            this.chUpdateTime});
            this.dgvCollectScheduleList.Location = new System.Drawing.Point(9, 9);
            this.dgvCollectScheduleList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvCollectScheduleList.MultiSelect = false;
            this.dgvCollectScheduleList.Name = "dgvCollectScheduleList";
            this.dgvCollectScheduleList.ReadOnly = true;
            this.dgvCollectScheduleList.RowTemplate.Height = 21;
            this.dgvCollectScheduleList.Size = new System.Drawing.Size(1136, 486);
            this.dgvCollectScheduleList.TabIndex = 0;
            // 
            // chReserveCode
            // 
            this.chReserveCode.HeaderText = "予備機コード";
            this.chReserveCode.Name = "chReserveCode";
            this.chReserveCode.ReadOnly = true;
            this.chReserveCode.Width = 120;
            // 
            // chMalfunctionCode
            // 
            this.chMalfunctionCode.HeaderText = "故障機コード";
            this.chMalfunctionCode.Name = "chMalfunctionCode";
            this.chMalfunctionCode.ReadOnly = true;
            this.chMalfunctionCode.Width = 120;
            // 
            // chItemType
            // 
            this.chItemType.HeaderText = "種別";
            this.chItemType.Name = "chItemType";
            this.chItemType.ReadOnly = true;
            // 
            // chItemState
            // 
            this.chItemState.HeaderText = "状態";
            this.chItemState.Name = "chItemState";
            this.chItemState.ReadOnly = true;
            // 
            // chShop
            // 
            this.chShop.HeaderText = "店舗";
            this.chShop.Name = "chShop";
            this.chShop.ReadOnly = true;
            this.chShop.Width = 80;
            // 
            // chCollectScheduleDate
            // 
            this.chCollectScheduleDate.HeaderText = "回収予定日時";
            this.chCollectScheduleDate.Name = "chCollectScheduleDate";
            this.chCollectScheduleDate.ReadOnly = true;
            this.chCollectScheduleDate.Width = 120;
            // 
            // chCollectDate
            // 
            this.chCollectDate.HeaderText = "回収完了日時";
            this.chCollectDate.Name = "chCollectDate";
            this.chCollectDate.ReadOnly = true;
            this.chCollectDate.Width = 120;
            // 
            // chInsertTime
            // 
            this.chInsertTime.HeaderText = "登録日時";
            this.chInsertTime.Name = "chInsertTime";
            this.chInsertTime.ReadOnly = true;
            this.chInsertTime.Width = 150;
            // 
            // chUpdateTime
            // 
            this.chUpdateTime.HeaderText = "更新日時";
            this.chUpdateTime.Name = "chUpdateTime";
            this.chUpdateTime.ReadOnly = true;
            this.chUpdateTime.Width = 150;
            // 
            // FormCollectScheduleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 504);
            this.Controls.Add(this.dgvCollectScheduleList);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCollectScheduleList";
            this.Text = "故障機回収予定一覧";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollectScheduleList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCollectScheduleList;
        private System.Windows.Forms.DataGridViewTextBoxColumn chReserveCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chMalfunctionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn chItemState;
        private System.Windows.Forms.DataGridViewTextBoxColumn chShop;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCollectScheduleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCollectDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn chInsertTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUpdateTime;
    }
}