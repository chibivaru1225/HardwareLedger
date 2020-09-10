namespace HardwareLedger
{
    partial class FormTypeMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTypeMaster));
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetailName = new System.Windows.Forms.TextBox();
            this.txtDetailCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTypeList = new System.Windows.Forms.DataGridView();
            this.chListCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRowDelete = new System.Windows.Forms.Button();
            this.btnRowAdd = new System.Windows.Forms.Button();
            this.btnRowSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeList)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "名前";
            // 
            // txtDetailName
            // 
            this.txtDetailName.Location = new System.Drawing.Point(58, 290);
            this.txtDetailName.Name = "txtDetailName";
            this.txtDetailName.Size = new System.Drawing.Size(200, 22);
            this.txtDetailName.TabIndex = 3;
            // 
            // txtDetailCode
            // 
            this.txtDetailCode.Location = new System.Drawing.Point(58, 262);
            this.txtDetailCode.Name = "txtDetailCode";
            this.txtDetailCode.ReadOnly = true;
            this.txtDetailCode.Size = new System.Drawing.Size(200, 22);
            this.txtDetailCode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "コード";
            // 
            // dgvTypeList
            // 
            this.dgvTypeList.AllowUserToAddRows = false;
            this.dgvTypeList.AllowUserToDeleteRows = false;
            this.dgvTypeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chListCode,
            this.chListName});
            this.dgvTypeList.Location = new System.Drawing.Point(12, 12);
            this.dgvTypeList.MultiSelect = false;
            this.dgvTypeList.Name = "dgvTypeList";
            this.dgvTypeList.ReadOnly = true;
            this.dgvTypeList.RowTemplate.Height = 21;
            this.dgvTypeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTypeList.Size = new System.Drawing.Size(300, 187);
            this.dgvTypeList.TabIndex = 4;
            // 
            // chListCode
            // 
            this.chListCode.HeaderText = "コード";
            this.chListCode.Name = "chListCode";
            this.chListCode.ReadOnly = true;
            this.chListCode.Width = 80;
            // 
            // chListName
            // 
            this.chListName.HeaderText = "名前";
            this.chListName.Name = "chListName";
            this.chListName.ReadOnly = true;
            this.chListName.Width = 140;
            // 
            // btnRowDelete
            // 
            this.btnRowDelete.Location = new System.Drawing.Point(186, 205);
            this.btnRowDelete.Name = "btnRowDelete";
            this.btnRowDelete.Size = new System.Drawing.Size(126, 51);
            this.btnRowDelete.TabIndex = 1;
            this.btnRowDelete.Text = "行削除";
            this.btnRowDelete.UseVisualStyleBackColor = true;
            // 
            // btnRowAdd
            // 
            this.btnRowAdd.Location = new System.Drawing.Point(12, 205);
            this.btnRowAdd.Name = "btnRowAdd";
            this.btnRowAdd.Size = new System.Drawing.Size(126, 51);
            this.btnRowAdd.TabIndex = 0;
            this.btnRowAdd.Text = "行追加";
            this.btnRowAdd.UseVisualStyleBackColor = true;
            // 
            // btnRowSave
            // 
            this.btnRowSave.Location = new System.Drawing.Point(186, 318);
            this.btnRowSave.Name = "btnRowSave";
            this.btnRowSave.Size = new System.Drawing.Size(126, 51);
            this.btnRowSave.TabIndex = 4;
            this.btnRowSave.Text = "保存";
            this.btnRowSave.UseVisualStyleBackColor = true;
            // 
            // FormTypeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 378);
            this.Controls.Add(this.btnRowSave);
            this.Controls.Add(this.btnRowDelete);
            this.Controls.Add(this.btnRowAdd);
            this.Controls.Add(this.dgvTypeList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDetailCode);
            this.Controls.Add(this.txtDetailName);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTypeMaster";
            this.Text = "種類登録";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetailName;
        private System.Windows.Forms.TextBox txtDetailCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTypeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn chListCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chListName;
        private System.Windows.Forms.Button btnRowDelete;
        private System.Windows.Forms.Button btnRowAdd;
        private System.Windows.Forms.Button btnRowSave;
    }
}