namespace barmanagement
{
    partial class TableMasterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTableNumber;
        private System.Windows.Forms.TextBox txtTableNumber;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTableNumber = new System.Windows.Forms.Label();
            this.txtTableNumber = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTableNumber
            this.lblTableNumber.AutoSize = true;
            this.lblTableNumber.Location = new System.Drawing.Point(30, 30);
            this.lblTableNumber.Name = "lblTableNumber";
            this.lblTableNumber.Size = new System.Drawing.Size(87, 15);
            this.lblTableNumber.TabIndex = 0;
            this.lblTableNumber.Text = "Table Number:";

            // txtTableNumber
            this.txtTableNumber.Location = new System.Drawing.Point(30, 50);
            this.txtTableNumber.Name = "txtTableNumber";
            this.txtTableNumber.Size = new System.Drawing.Size(200, 23);
            this.txtTableNumber.TabIndex = 1;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(30, 90);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(60, 15);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category:";

            // cmbCategory
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] { "General", "AC", "Garden" });
            this.cmbCategory.Location = new System.Drawing.Point(30, 110);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 23);
            this.cmbCategory.TabIndex = 3;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(30, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save Table";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // TableMasterForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 220);
            this.Controls.Add(this.lblTableNumber);
            this.Controls.Add(this.txtTableNumber);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnSave);
            this.Name = "TableMasterForm";
            this.Text = "Table Master";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
