namespace HardwareLedger
{
    partial class FormReserveRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReserveRegister));
            this.cbxItemType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxItemState = new System.Windows.Forms.ComboBox();
            this.btnRegist = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxItemType
            // 
            this.cbxItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxItemType.FormattingEnabled = true;
            this.cbxItemType.Location = new System.Drawing.Point(55, 12);
            this.cbxItemType.Name = "cbxItemType";
            this.cbxItemType.Size = new System.Drawing.Size(184, 23);
            this.cbxItemType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "種別";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(55, 41);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(184, 22);
            this.txtItemName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "名前";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "状態";
            // 
            // cbxItemState
            // 
            this.cbxItemState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxItemState.FormattingEnabled = true;
            this.cbxItemState.Location = new System.Drawing.Point(55, 69);
            this.cbxItemState.Name = "cbxItemState";
            this.cbxItemState.Size = new System.Drawing.Size(184, 23);
            this.cbxItemState.TabIndex = 5;
            // 
            // btnRegist
            // 
            this.btnRegist.Location = new System.Drawing.Point(15, 98);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(109, 72);
            this.btnRegist.TabIndex = 6;
            this.btnRegist.Text = "登録";
            this.btnRegist.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(130, 98);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 72);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormReserveRegister
            // 
            this.AcceptButton = this.btnRegist;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(251, 182);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegist);
            this.Controls.Add(this.cbxItemState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxItemType);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReserveRegister";
            this.Text = "予備機登録";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxItemType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxItemState;
        private System.Windows.Forms.Button btnRegist;
        private System.Windows.Forms.Button btnCancel;
    }
}