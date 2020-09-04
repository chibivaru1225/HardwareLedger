namespace HardwareLedger
{
    partial class FormMenu
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReserveList = new System.Windows.Forms.Button();
            this.btnReserveRegister = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCollectScheduleAdd = new System.Windows.Forms.Button();
            this.btnCollectScheduleList = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTypeMaster = new System.Windows.Forms.Button();
            this.btnStateMaster = new System.Windows.Forms.Button();
            this.btnShopMaster = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReserveList);
            this.groupBox1.Controls.Add(this.btnReserveRegister);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(476, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "予備機";
            // 
            // btnReserveList
            // 
            this.btnReserveList.Location = new System.Drawing.Point(163, 22);
            this.btnReserveList.Name = "btnReserveList";
            this.btnReserveList.Size = new System.Drawing.Size(150, 50);
            this.btnReserveList.TabIndex = 1;
            this.btnReserveList.Text = "予備機一覧";
            this.btnReserveList.UseVisualStyleBackColor = true;
            // 
            // btnReserveRegister
            // 
            this.btnReserveRegister.Location = new System.Drawing.Point(7, 22);
            this.btnReserveRegister.Name = "btnReserveRegister";
            this.btnReserveRegister.Size = new System.Drawing.Size(150, 50);
            this.btnReserveRegister.TabIndex = 0;
            this.btnReserveRegister.Text = "予備機登録";
            this.btnReserveRegister.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCollectScheduleAdd);
            this.groupBox2.Controls.Add(this.btnCollectScheduleList);
            this.groupBox2.Location = new System.Drawing.Point(9, 96);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(476, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "故障機";
            // 
            // btnCollectScheduleAdd
            // 
            this.btnCollectScheduleAdd.Location = new System.Drawing.Point(7, 22);
            this.btnCollectScheduleAdd.Name = "btnCollectScheduleAdd";
            this.btnCollectScheduleAdd.Size = new System.Drawing.Size(150, 50);
            this.btnCollectScheduleAdd.TabIndex = 3;
            this.btnCollectScheduleAdd.Text = "故障機\r\n回収予定登録";
            this.btnCollectScheduleAdd.UseVisualStyleBackColor = true;
            // 
            // btnCollectScheduleList
            // 
            this.btnCollectScheduleList.Location = new System.Drawing.Point(163, 22);
            this.btnCollectScheduleList.Name = "btnCollectScheduleList";
            this.btnCollectScheduleList.Size = new System.Drawing.Size(150, 50);
            this.btnCollectScheduleList.TabIndex = 2;
            this.btnCollectScheduleList.Text = "故障機\r\n回収予定一覧";
            this.btnCollectScheduleList.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnShopMaster);
            this.groupBox3.Controls.Add(this.btnTypeMaster);
            this.groupBox3.Controls.Add(this.btnStateMaster);
            this.groupBox3.Location = new System.Drawing.Point(9, 179);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(476, 79);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "マスタ";
            // 
            // btnTypeMaster
            // 
            this.btnTypeMaster.Location = new System.Drawing.Point(7, 22);
            this.btnTypeMaster.Name = "btnTypeMaster";
            this.btnTypeMaster.Size = new System.Drawing.Size(150, 50);
            this.btnTypeMaster.TabIndex = 4;
            this.btnTypeMaster.Text = "種別マスタ";
            this.btnTypeMaster.UseVisualStyleBackColor = true;
            // 
            // btnStateMaster
            // 
            this.btnStateMaster.Location = new System.Drawing.Point(163, 22);
            this.btnStateMaster.Name = "btnStateMaster";
            this.btnStateMaster.Size = new System.Drawing.Size(150, 50);
            this.btnStateMaster.TabIndex = 3;
            this.btnStateMaster.Text = "状態マスタ";
            this.btnStateMaster.UseVisualStyleBackColor = true;
            // 
            // btnShopMaster
            // 
            this.btnShopMaster.Location = new System.Drawing.Point(319, 22);
            this.btnShopMaster.Name = "btnShopMaster";
            this.btnShopMaster.Size = new System.Drawing.Size(150, 50);
            this.btnShopMaster.TabIndex = 5;
            this.btnShopMaster.Text = "店マスタ";
            this.btnShopMaster.UseVisualStyleBackColor = true;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 267);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMenu";
            this.Text = "ハードウェア管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReserveList;
        private System.Windows.Forms.Button btnReserveRegister;
        private System.Windows.Forms.Button btnCollectScheduleList;
        private System.Windows.Forms.Button btnCollectScheduleAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStateMaster;
        private System.Windows.Forms.Button btnTypeMaster;
        private System.Windows.Forms.Button btnShopMaster;
    }
}

