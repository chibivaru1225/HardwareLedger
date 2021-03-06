﻿namespace HardwareLedger
{
    partial class FormReserveDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReserveDetail));
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInsertTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.btnCollectRegist = new System.Windows.Forms.Button();
            this.txtCollectSchedule = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCSCheck = new System.Windows.Forms.Button();
            this.btnShipping = new System.Windows.Forms.Button();
            this.txtShipping = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtModelNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxZaiko = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(130, 12);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(194, 23);
            this.cbxType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "種別";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 70);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(194, 22);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "名前";
            // 
            // cbxState
            // 
            this.cbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Location = new System.Drawing.Point(130, 126);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(194, 23);
            this.cbxState.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "状態";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(118, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 52);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 268);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 52);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "登録日時";
            // 
            // txtInsertTime
            // 
            this.txtInsertTime.Location = new System.Drawing.Point(130, 212);
            this.txtInsertTime.Name = "txtInsertTime";
            this.txtInsertTime.ReadOnly = true;
            this.txtInsertTime.Size = new System.Drawing.Size(194, 22);
            this.txtInsertTime.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "更新日時";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(130, 240);
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(194, 22);
            this.txtUpdateTime.TabIndex = 8;
            // 
            // btnCollectRegist
            // 
            this.btnCollectRegist.Location = new System.Drawing.Point(330, 12);
            this.btnCollectRegist.Name = "btnCollectRegist";
            this.btnCollectRegist.Size = new System.Drawing.Size(100, 52);
            this.btnCollectRegist.TabIndex = 13;
            this.btnCollectRegist.Text = "回収予定\r\n登録/変更";
            this.btnCollectRegist.UseVisualStyleBackColor = true;
            // 
            // txtCollectSchedule
            // 
            this.txtCollectSchedule.Location = new System.Drawing.Point(130, 155);
            this.txtCollectSchedule.Name = "txtCollectSchedule";
            this.txtCollectSchedule.ReadOnly = true;
            this.txtCollectSchedule.Size = new System.Drawing.Size(194, 22);
            this.txtCollectSchedule.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "故障機回収状況";
            // 
            // btnCSCheck
            // 
            this.btnCSCheck.Location = new System.Drawing.Point(330, 70);
            this.btnCSCheck.Name = "btnCSCheck";
            this.btnCSCheck.Size = new System.Drawing.Size(100, 50);
            this.btnCSCheck.TabIndex = 14;
            this.btnCSCheck.Text = "回収状況\r\n閲覧";
            this.btnCSCheck.UseVisualStyleBackColor = true;
            this.btnCSCheck.Visible = false;
            // 
            // btnShipping
            // 
            this.btnShipping.Location = new System.Drawing.Point(330, 126);
            this.btnShipping.Name = "btnShipping";
            this.btnShipping.Size = new System.Drawing.Size(100, 51);
            this.btnShipping.TabIndex = 15;
            this.btnShipping.Text = "発送状況\r\n登録/変更";
            this.btnShipping.UseVisualStyleBackColor = true;
            // 
            // txtShipping
            // 
            this.txtShipping.Location = new System.Drawing.Point(130, 183);
            this.txtShipping.Name = "txtShipping";
            this.txtShipping.ReadOnly = true;
            this.txtShipping.Size = new System.Drawing.Size(194, 22);
            this.txtShipping.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "予備機発送状況";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "型番";
            // 
            // txtModelNo
            // 
            this.txtModelNo.Location = new System.Drawing.Point(130, 98);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Size = new System.Drawing.Size(194, 22);
            this.txtModelNo.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "在庫区分";
            // 
            // cbxZaiko
            // 
            this.cbxZaiko.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxZaiko.FormattingEnabled = true;
            this.cbxZaiko.Location = new System.Drawing.Point(130, 41);
            this.cbxZaiko.Name = "cbxZaiko";
            this.cbxZaiko.Size = new System.Drawing.Size(194, 23);
            this.cbxZaiko.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.Location = new System.Drawing.Point(224, 268);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 52);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnReprint
            // 
            this.btnReprint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReprint.Location = new System.Drawing.Point(330, 268);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(100, 52);
            this.btnReprint.TabIndex = 12;
            this.btnReprint.Text = "ラベル\r\n再印刷";
            this.btnReprint.UseVisualStyleBackColor = true;
            // 
            // FormReserveDetail
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(442, 332);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxZaiko);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtModelNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtShipping);
            this.Controls.Add(this.btnShipping);
            this.Controls.Add(this.btnCSCheck);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCollectSchedule);
            this.Controls.Add(this.btnCollectRegist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUpdateTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInsertTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxType);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormReserveDetail";
            this.Text = "予備機明細";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInsertTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.Button btnCollectRegist;
        private System.Windows.Forms.TextBox txtCollectSchedule;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCSCheck;
        private System.Windows.Forms.Button btnShipping;
        private System.Windows.Forms.TextBox txtShipping;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtModelNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxZaiko;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReprint;
    }
}