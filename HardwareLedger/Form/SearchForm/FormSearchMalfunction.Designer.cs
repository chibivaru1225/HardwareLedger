namespace HardwareLedger
{
    partial class FormSearchMalfunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchMalfunction));
            this.dgvMalfunctionList = new System.Windows.Forms.DataGridView();
            this.chMalfunctionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chModelNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chShop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chInsertTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalfunctionList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMalfunctionList
            // 
            this.dgvMalfunctionList.AllowUserToAddRows = false;
            this.dgvMalfunctionList.AllowUserToDeleteRows = false;
            this.dgvMalfunctionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMalfunctionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chMalfunctionCode,
            this.chItemType,
            this.chName,
            this.chModelNo,
            this.chState,
            this.chShop,
            this.chInsertTime,
            this.chUpdateTime});
            this.dgvMalfunctionList.Location = new System.Drawing.Point(9, 9);
            this.dgvMalfunctionList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMalfunctionList.Name = "dgvMalfunctionList";
            this.dgvMalfunctionList.ReadOnly = true;
            this.dgvMalfunctionList.RowTemplate.Height = 21;
            this.dgvMalfunctionList.Size = new System.Drawing.Size(1049, 544);
            this.dgvMalfunctionList.TabIndex = 0;
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
            // chName
            // 
            this.chName.HeaderText = "名前";
            this.chName.Name = "chName";
            this.chName.ReadOnly = true;
            // 
            // chModelNo
            // 
            this.chModelNo.HeaderText = "型番";
            this.chModelNo.Name = "chModelNo";
            this.chModelNo.ReadOnly = true;
            // 
            // chState
            // 
            this.chState.HeaderText = "状態";
            this.chState.Name = "chState";
            this.chState.ReadOnly = true;
            // 
            // chShop
            // 
            this.chShop.HeaderText = "店番";
            this.chShop.Name = "chShop";
            this.chShop.ReadOnly = true;
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
            // FormSearchMalfunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.dgvMalfunctionList);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchMalfunction";
            this.Text = "故障機検索";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalfunctionList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMalfunctionList;
        private System.Windows.Forms.DataGridViewTextBoxColumn chMalfunctionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn chName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chModelNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chState;
        private System.Windows.Forms.DataGridViewTextBoxColumn chShop;
        private System.Windows.Forms.DataGridViewTextBoxColumn chInsertTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUpdateTime;
    }
}