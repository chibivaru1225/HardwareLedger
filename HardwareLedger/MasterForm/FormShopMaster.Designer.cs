namespace HardwareLedger
{
    partial class FormShopMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShopMaster));
            this.dgvShopList = new System.Windows.Forms.DataGridView();
            this.chListRowState = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chListNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShopCode = new System.Windows.Forms.TextBox();
            this.txtShopName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRowSave = new System.Windows.Forms.Button();
            this.btnRowAdd = new System.Windows.Forms.Button();
            this.txtShopNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEnable = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShopList
            // 
            this.dgvShopList.AllowUserToAddRows = false;
            this.dgvShopList.AllowUserToDeleteRows = false;
            this.dgvShopList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShopList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chListRowState,
            this.chListNum,
            this.chListName});
            this.dgvShopList.Location = new System.Drawing.Point(12, 12);
            this.dgvShopList.MultiSelect = false;
            this.dgvShopList.Name = "dgvShopList";
            this.dgvShopList.ReadOnly = true;
            this.dgvShopList.RowTemplate.Height = 21;
            this.dgvShopList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShopList.Size = new System.Drawing.Size(460, 187);
            this.dgvShopList.TabIndex = 0;
            // 
            // chListRowState
            // 
            this.chListRowState.HeaderText = "表示";
            this.chListRowState.Name = "chListRowState";
            this.chListRowState.ReadOnly = true;
            this.chListRowState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chListRowState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chListRowState.Width = 80;
            // 
            // chListNum
            // 
            this.chListNum.HeaderText = "店番";
            this.chListNum.Name = "chListNum";
            this.chListNum.ReadOnly = true;
            this.chListNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.chListNum.Width = 80;
            // 
            // chListName
            // 
            this.chListName.HeaderText = "名前";
            this.chListName.Name = "chListName";
            this.chListName.ReadOnly = true;
            this.chListName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.chListName.Width = 220;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "コード";
            // 
            // txtShopCode
            // 
            this.txtShopCode.Location = new System.Drawing.Point(58, 289);
            this.txtShopCode.Name = "txtShopCode";
            this.txtShopCode.ReadOnly = true;
            this.txtShopCode.Size = new System.Drawing.Size(200, 22);
            this.txtShopCode.TabIndex = 3;
            // 
            // txtShopName
            // 
            this.txtShopName.Location = new System.Drawing.Point(58, 345);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(200, 22);
            this.txtShopName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "名前";
            // 
            // btnRowSave
            // 
            this.btnRowSave.Location = new System.Drawing.Point(346, 316);
            this.btnRowSave.Name = "btnRowSave";
            this.btnRowSave.Size = new System.Drawing.Size(126, 51);
            this.btnRowSave.TabIndex = 6;
            this.btnRowSave.Text = "保存";
            this.btnRowSave.UseVisualStyleBackColor = true;
            // 
            // btnRowAdd
            // 
            this.btnRowAdd.Location = new System.Drawing.Point(12, 205);
            this.btnRowAdd.Name = "btnRowAdd";
            this.btnRowAdd.Size = new System.Drawing.Size(126, 51);
            this.btnRowAdd.TabIndex = 1;
            this.btnRowAdd.Text = "行追加";
            this.btnRowAdd.UseVisualStyleBackColor = true;
            // 
            // txtShopNum
            // 
            this.txtShopNum.Location = new System.Drawing.Point(58, 317);
            this.txtShopNum.Name = "txtShopNum";
            this.txtShopNum.Size = new System.Drawing.Size(200, 22);
            this.txtShopNum.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "店番";
            // 
            // cbEnable
            // 
            this.cbEnable.AutoSize = true;
            this.cbEnable.Location = new System.Drawing.Point(12, 264);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(80, 19);
            this.cbEnable.TabIndex = 2;
            this.cbEnable.Text = "表示する";
            this.cbEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbEnable.UseVisualStyleBackColor = true;
            // 
            // FormShopMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 379);
            this.Controls.Add(this.txtShopNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvShopList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtShopCode);
            this.Controls.Add(this.txtShopName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRowSave);
            this.Controls.Add(this.btnRowAdd);
            this.Controls.Add(this.cbEnable);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShopMaster";
            this.Text = "店舗登録";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShopList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShopCode;
        private System.Windows.Forms.TextBox txtShopName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRowSave;
        private System.Windows.Forms.Button btnRowAdd;
        private System.Windows.Forms.TextBox txtShopNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbEnable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chListRowState;
        private System.Windows.Forms.DataGridViewTextBoxColumn chListNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn chListName;
    }
}