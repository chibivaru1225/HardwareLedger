namespace HardwareLedger
{
    partial class FormMalfunctionRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMalfunctionRegister));
            this.label8 = new System.Windows.Forms.Label();
            this.cbxShop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRegist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 42;
            this.label8.Text = "店舗";
            // 
            // cbxShop
            // 
            this.cbxShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxShop.FormattingEnabled = true;
            this.cbxShop.Location = new System.Drawing.Point(55, 69);
            this.cbxShop.Name = "cbxShop";
            this.cbxShop.Size = new System.Drawing.Size(185, 23);
            this.cbxShop.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 40;
            this.label3.Text = "状態";
            // 
            // cbxState
            // 
            this.cbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Location = new System.Drawing.Point(55, 98);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(185, 23);
            this.cbxState.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "種別";
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(56, 12);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(185, 23);
            this.cbxType.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 44;
            this.label2.Text = "名前";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(56, 41);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(184, 22);
            this.txtItemName.TabIndex = 43;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(131, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 72);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRegist
            // 
            this.btnRegist.Location = new System.Drawing.Point(16, 127);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(109, 72);
            this.btnRegist.TabIndex = 45;
            this.btnRegist.Text = "登録";
            this.btnRegist.UseVisualStyleBackColor = true;
            // 
            // FormMalfunctionRegister
            // 
            this.AcceptButton = this.btnRegist;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(252, 211);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegist);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxShop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxType);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMalfunctionRegister";
            this.Text = "故障機登録";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxShop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRegist;
    }
}