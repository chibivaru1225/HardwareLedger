namespace HardwareLedger
{
    partial class FormShippingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShippingList));
            this.dgvShippingList = new System.Windows.Forms.DataGridView();
            this.chShippingCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chReserveCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chShopCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chShippingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chInsertTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShippingList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShippingList
            // 
            this.dgvShippingList.AllowUserToAddRows = false;
            this.dgvShippingList.AllowUserToDeleteRows = false;
            this.dgvShippingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShippingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chShippingCode,
            this.chReserveCode,
            this.chShopCode,
            this.chState,
            this.chShippingTime,
            this.chInsertTime,
            this.chUpdateTime});
            this.dgvShippingList.Location = new System.Drawing.Point(12, 11);
            this.dgvShippingList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvShippingList.Name = "dgvShippingList";
            this.dgvShippingList.ReadOnly = true;
            this.dgvShippingList.RowTemplate.Height = 21;
            this.dgvShippingList.Size = new System.Drawing.Size(946, 473);
            this.dgvShippingList.TabIndex = 0;
            // 
            // chShippingCode
            // 
            this.chShippingCode.HeaderText = "発送コード";
            this.chShippingCode.Name = "chShippingCode";
            this.chShippingCode.ReadOnly = true;
            // 
            // chReserveCode
            // 
            this.chReserveCode.HeaderText = "予備機コード";
            this.chReserveCode.Name = "chReserveCode";
            this.chReserveCode.ReadOnly = true;
            this.chReserveCode.Width = 120;
            // 
            // chShopCode
            // 
            this.chShopCode.HeaderText = "店番";
            this.chShopCode.Name = "chShopCode";
            this.chShopCode.ReadOnly = true;
            // 
            // chState
            // 
            this.chState.HeaderText = "状況";
            this.chState.Name = "chState";
            this.chState.ReadOnly = true;
            // 
            // chShippingTime
            // 
            this.chShippingTime.HeaderText = "発送日時";
            this.chShippingTime.Name = "chShippingTime";
            this.chShippingTime.ReadOnly = true;
            this.chShippingTime.Width = 150;
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
            // FormShippingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 493);
            this.Controls.Add(this.dgvShippingList);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShippingList";
            this.Text = "発送状況一覧";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShippingList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShippingList;
        private System.Windows.Forms.DataGridViewTextBoxColumn chShippingCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chReserveCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chShopCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chState;
        private System.Windows.Forms.DataGridViewTextBoxColumn chShippingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn chInsertTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUpdateTime;
    }
}