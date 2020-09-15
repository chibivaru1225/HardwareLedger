namespace HardwareLedger
{
    partial class FormOutputExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOutputExcel));
            this.btnOutputExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOutputExcel
            // 
            this.btnOutputExcel.Location = new System.Drawing.Point(12, 12);
            this.btnOutputExcel.Name = "btnOutputExcel";
            this.btnOutputExcel.Size = new System.Drawing.Size(210, 87);
            this.btnOutputExcel.TabIndex = 0;
            this.btnOutputExcel.Text = "エクセル出力";
            this.btnOutputExcel.UseVisualStyleBackColor = true;
            // 
            // FormOutputExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 111);
            this.Controls.Add(this.btnOutputExcel);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormOutputExcel";
            this.Text = "エクセル出力";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOutputExcel;
    }
}