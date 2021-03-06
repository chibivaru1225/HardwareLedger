﻿namespace HardwareLedger
{
    partial class FormCollectScheduleRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCollectScheduleRegister));
            this.label3 = new System.Windows.Forms.Label();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.dtpScheduleTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtReserveCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMalfunctionCode = new System.Windows.Forms.TextBox();
            this.cbCollected = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpCollectedTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxShop = new System.Windows.Forms.ComboBox();
            this.btnReserveSelect = new System.Windows.Forms.Button();
            this.btnMalfuinctionSelect = new System.Windows.Forms.Button();
            this.btnReserveClear = new System.Windows.Forms.Button();
            this.btnMalfunctionClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "状態";
            // 
            // cbxState
            // 
            this.cbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Location = new System.Drawing.Point(103, 126);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(262, 23);
            this.cbxState.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "種別";
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(103, 68);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(262, 23);
            this.cbxType.TabIndex = 6;
            // 
            // dtpScheduleTime
            // 
            this.dtpScheduleTime.Location = new System.Drawing.Point(103, 155);
            this.dtpScheduleTime.Name = "dtpScheduleTime";
            this.dtpScheduleTime.Size = new System.Drawing.Size(262, 22);
            this.dtpScheduleTime.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "回収予定";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(230, 239);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 72);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 239);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(135, 72);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "登録/更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtReserveCode
            // 
            this.txtReserveCode.Location = new System.Drawing.Point(103, 12);
            this.txtReserveCode.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.txtReserveCode.Name = "txtReserveCode";
            this.txtReserveCode.ReadOnly = true;
            this.txtReserveCode.Size = new System.Drawing.Size(162, 22);
            this.txtReserveCode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "予備機コード";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "故障機コード";
            // 
            // txtMalfunctionCode
            // 
            this.txtMalfunctionCode.Location = new System.Drawing.Point(103, 40);
            this.txtMalfunctionCode.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.txtMalfunctionCode.Name = "txtMalfunctionCode";
            this.txtMalfunctionCode.ReadOnly = true;
            this.txtMalfunctionCode.Size = new System.Drawing.Size(162, 22);
            this.txtMalfunctionCode.TabIndex = 3;
            // 
            // cbCollected
            // 
            this.cbCollected.AutoSize = true;
            this.cbCollected.Location = new System.Drawing.Point(103, 188);
            this.cbCollected.Name = "cbCollected";
            this.cbCollected.Size = new System.Drawing.Size(71, 19);
            this.cbCollected.TabIndex = 10;
            this.cbCollected.Text = "回収済";
            this.cbCollected.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "回収済";
            // 
            // dtpCollectedTime
            // 
            this.dtpCollectedTime.Location = new System.Drawing.Point(103, 211);
            this.dtpCollectedTime.Name = "dtpCollectedTime";
            this.dtpCollectedTime.Size = new System.Drawing.Size(262, 22);
            this.dtpCollectedTime.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "回収日";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 36;
            this.label8.Text = "店舗";
            // 
            // cbxShop
            // 
            this.cbxShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxShop.FormattingEnabled = true;
            this.cbxShop.Location = new System.Drawing.Point(103, 97);
            this.cbxShop.Name = "cbxShop";
            this.cbxShop.Size = new System.Drawing.Size(262, 23);
            this.cbxShop.TabIndex = 7;
            // 
            // btnReserveSelect
            // 
            this.btnReserveSelect.Location = new System.Drawing.Point(265, 11);
            this.btnReserveSelect.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnReserveSelect.Name = "btnReserveSelect";
            this.btnReserveSelect.Size = new System.Drawing.Size(50, 23);
            this.btnReserveSelect.TabIndex = 1;
            this.btnReserveSelect.Text = "選択";
            this.btnReserveSelect.UseVisualStyleBackColor = true;
            // 
            // btnMalfuinctionSelect
            // 
            this.btnMalfuinctionSelect.Location = new System.Drawing.Point(265, 39);
            this.btnMalfuinctionSelect.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnMalfuinctionSelect.Name = "btnMalfuinctionSelect";
            this.btnMalfuinctionSelect.Size = new System.Drawing.Size(50, 23);
            this.btnMalfuinctionSelect.TabIndex = 4;
            this.btnMalfuinctionSelect.Text = "選択";
            this.btnMalfuinctionSelect.UseVisualStyleBackColor = true;
            // 
            // btnReserveClear
            // 
            this.btnReserveClear.Location = new System.Drawing.Point(315, 11);
            this.btnReserveClear.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnReserveClear.Name = "btnReserveClear";
            this.btnReserveClear.Size = new System.Drawing.Size(50, 23);
            this.btnReserveClear.TabIndex = 2;
            this.btnReserveClear.Text = "解除";
            this.btnReserveClear.UseVisualStyleBackColor = true;
            // 
            // btnMalfunctionClear
            // 
            this.btnMalfunctionClear.Location = new System.Drawing.Point(315, 39);
            this.btnMalfunctionClear.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnMalfunctionClear.Name = "btnMalfunctionClear";
            this.btnMalfunctionClear.Size = new System.Drawing.Size(50, 23);
            this.btnMalfunctionClear.TabIndex = 5;
            this.btnMalfunctionClear.Text = "解除";
            this.btnMalfunctionClear.UseVisualStyleBackColor = true;
            // 
            // FormCollectScheduleRegister
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(377, 323);
            this.Controls.Add(this.btnMalfunctionClear);
            this.Controls.Add(this.btnReserveClear);
            this.Controls.Add(this.btnMalfuinctionSelect);
            this.Controls.Add(this.btnReserveSelect);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxShop);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpCollectedTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbCollected);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMalfunctionCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpScheduleTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReserveCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxType);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCollectScheduleRegister";
            this.Text = "故障機回収予定登録";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.DateTimePicker dtpScheduleTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtReserveCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMalfunctionCode;
        private System.Windows.Forms.CheckBox cbCollected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpCollectedTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxShop;
        private System.Windows.Forms.Button btnReserveSelect;
        private System.Windows.Forms.Button btnMalfuinctionSelect;
        private System.Windows.Forms.Button btnReserveClear;
        private System.Windows.Forms.Button btnMalfunctionClear;
    }
}