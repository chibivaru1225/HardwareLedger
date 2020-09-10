namespace HardwareLedger
{
    partial class FormStateMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStateMaster));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRowSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvApplyKbnList = new System.Windows.Forms.DataGridView();
            this.chDetailIsApply = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chDetailApplyKbns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDetailColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetailName = new System.Windows.Forms.TextBox();
            this.txtDetailCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStateList = new System.Windows.Forms.DataGridView();
            this.chListCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chListApplyKbn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chListColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRowDelete = new System.Windows.Forms.Button();
            this.btnRowAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyKbnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStateList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRowSave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvApplyKbnList);
            this.groupBox1.Controls.Add(this.btnDetailColor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDetailName);
            this.groupBox1.Controls.Add(this.txtDetailCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 280);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 373);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "詳細";
            // 
            // btnRowSave
            // 
            this.btnRowSave.Location = new System.Drawing.Point(399, 76);
            this.btnRowSave.Name = "btnRowSave";
            this.btnRowSave.Size = new System.Drawing.Size(126, 51);
            this.btnRowSave.TabIndex = 3;
            this.btnRowSave.Text = "保存";
            this.btnRowSave.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "適用区分";
            // 
            // dgvApplyKbnList
            // 
            this.dgvApplyKbnList.AllowUserToAddRows = false;
            this.dgvApplyKbnList.AllowUserToDeleteRows = false;
            this.dgvApplyKbnList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplyKbnList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chDetailIsApply,
            this.chDetailApplyKbns});
            this.dgvApplyKbnList.Location = new System.Drawing.Point(6, 133);
            this.dgvApplyKbnList.MultiSelect = false;
            this.dgvApplyKbnList.Name = "dgvApplyKbnList";
            this.dgvApplyKbnList.RowTemplate.Height = 21;
            this.dgvApplyKbnList.Size = new System.Drawing.Size(519, 234);
            this.dgvApplyKbnList.TabIndex = 4;
            // 
            // chDetailIsApply
            // 
            this.chDetailIsApply.HeaderText = "適用";
            this.chDetailIsApply.Name = "chDetailIsApply";
            this.chDetailIsApply.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chDetailIsApply.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // chDetailApplyKbns
            // 
            this.chDetailApplyKbns.HeaderText = "適用区分";
            this.chDetailApplyKbns.Name = "chDetailApplyKbns";
            this.chDetailApplyKbns.Width = 200;
            // 
            // btnDetailColor
            // 
            this.btnDetailColor.BackColor = System.Drawing.Color.White;
            this.btnDetailColor.Location = new System.Drawing.Point(79, 77);
            this.btnDetailColor.Name = "btnDetailColor";
            this.btnDetailColor.Size = new System.Drawing.Size(200, 22);
            this.btnDetailColor.TabIndex = 2;
            this.btnDetailColor.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "行の色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "名前";
            // 
            // txtDetailName
            // 
            this.txtDetailName.Location = new System.Drawing.Point(79, 49);
            this.txtDetailName.Name = "txtDetailName";
            this.txtDetailName.Size = new System.Drawing.Size(200, 22);
            this.txtDetailName.TabIndex = 1;
            // 
            // txtDetailCode
            // 
            this.txtDetailCode.Location = new System.Drawing.Point(79, 21);
            this.txtDetailCode.Name = "txtDetailCode";
            this.txtDetailCode.ReadOnly = true;
            this.txtDetailCode.Size = new System.Drawing.Size(200, 22);
            this.txtDetailCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "コード";
            // 
            // dgvStateList
            // 
            this.dgvStateList.AllowUserToAddRows = false;
            this.dgvStateList.AllowUserToDeleteRows = false;
            this.dgvStateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStateList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chListCode,
            this.chListApplyKbn,
            this.chListName,
            this.chListColor});
            this.dgvStateList.Location = new System.Drawing.Point(6, 21);
            this.dgvStateList.MultiSelect = false;
            this.dgvStateList.Name = "dgvStateList";
            this.dgvStateList.ReadOnly = true;
            this.dgvStateList.RowTemplate.Height = 21;
            this.dgvStateList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStateList.Size = new System.Drawing.Size(519, 187);
            this.dgvStateList.TabIndex = 0;
            // 
            // chListCode
            // 
            this.chListCode.HeaderText = "コード";
            this.chListCode.Name = "chListCode";
            this.chListCode.ReadOnly = true;
            this.chListCode.Width = 80;
            // 
            // chListApplyKbn
            // 
            this.chListApplyKbn.HeaderText = "適用状態";
            this.chListApplyKbn.Name = "chListApplyKbn";
            this.chListApplyKbn.ReadOnly = true;
            this.chListApplyKbn.Width = 120;
            // 
            // chListName
            // 
            this.chListName.HeaderText = "名前";
            this.chListName.Name = "chListName";
            this.chListName.ReadOnly = true;
            this.chListName.Width = 140;
            // 
            // chListColor
            // 
            this.chListColor.HeaderText = "行の色";
            this.chListColor.Name = "chListColor";
            this.chListColor.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRowDelete);
            this.groupBox2.Controls.Add(this.btnRowAdd);
            this.groupBox2.Controls.Add(this.dgvStateList);
            this.groupBox2.Location = new System.Drawing.Point(9, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 271);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "一覧";
            // 
            // btnRowDelete
            // 
            this.btnRowDelete.Location = new System.Drawing.Point(399, 214);
            this.btnRowDelete.Name = "btnRowDelete";
            this.btnRowDelete.Size = new System.Drawing.Size(126, 51);
            this.btnRowDelete.TabIndex = 1;
            this.btnRowDelete.Text = "行削除";
            this.btnRowDelete.UseVisualStyleBackColor = true;
            // 
            // btnRowAdd
            // 
            this.btnRowAdd.Location = new System.Drawing.Point(6, 214);
            this.btnRowAdd.Name = "btnRowAdd";
            this.btnRowAdd.Size = new System.Drawing.Size(126, 51);
            this.btnRowAdd.TabIndex = 0;
            this.btnRowAdd.Text = "行追加";
            this.btnRowAdd.UseVisualStyleBackColor = true;
            // 
            // FormStateMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 662);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStateMaster";
            this.Text = "状態登録";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyKbnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStateList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvStateList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRowAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvApplyKbnList;
        private System.Windows.Forms.Button btnDetailColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetailName;
        private System.Windows.Forms.TextBox txtDetailCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRowDelete;
        private System.Windows.Forms.Button btnRowSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chDetailIsApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDetailApplyKbns;
        private System.Windows.Forms.DataGridViewTextBoxColumn chListCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chListApplyKbn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chListColor;
    }
}