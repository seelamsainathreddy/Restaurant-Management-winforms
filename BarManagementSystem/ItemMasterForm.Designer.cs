namespace barmanagement
{
    partial class ItemMasterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMenuSection;
        private System.Windows.Forms.ComboBox cmbMenuSection;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblShortCode;
        private System.Windows.Forms.TextBox txtShortCode;
        private System.Windows.Forms.DataGridView dgvPrices;
        private System.Windows.Forms.Button btnSave;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblMenuSection = new System.Windows.Forms.Label();
            this.cmbMenuSection = new System.Windows.Forms.ComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblShortCode = new System.Windows.Forms.Label();
            this.txtShortCode = new System.Windows.Forms.TextBox();
            this.dgvPrices = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrices)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMenuSection
            // 
            this.lblMenuSection.AutoSize = true;
            this.lblMenuSection.Location = new System.Drawing.Point(20, 20);
            this.lblMenuSection.Name = "lblMenuSection";
            this.lblMenuSection.Size = new System.Drawing.Size(82, 15);
            this.lblMenuSection.TabIndex = 0;
            this.lblMenuSection.Text = "Menu Section:";
            // 
            // cmbMenuSection
            // 
            this.cmbMenuSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMenuSection.FormattingEnabled = true;
            this.cmbMenuSection.Location = new System.Drawing.Point(120, 17);
            this.cmbMenuSection.Name = "cmbMenuSection";
            this.cmbMenuSection.Size = new System.Drawing.Size(200, 23);
            this.cmbMenuSection.TabIndex = 1;
            this.cmbMenuSection.SelectedIndexChanged += new System.EventHandler(this.cmbMenuSection_SelectedIndexChanged);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(20, 60);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(65, 15);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "Item Name:";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(120, 57);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(200, 23);
            this.txtItemName.TabIndex = 3;
            // 
            // lblShortCode
            // 
            this.lblShortCode.AutoSize = true;
            this.lblShortCode.Location = new System.Drawing.Point(20, 100);
            this.lblShortCode.Name = "lblShortCode";
            this.lblShortCode.Size = new System.Drawing.Size(66, 15);
            this.lblShortCode.TabIndex = 4;
            this.lblShortCode.Text = "Short Code:";
            // 
            // txtShortCode
            // 
            this.txtShortCode.Location = new System.Drawing.Point(120, 97);
            this.txtShortCode.Name = "txtShortCode";
            this.txtShortCode.Size = new System.Drawing.Size(200, 23);
            this.txtShortCode.TabIndex = 5;
            // 
            // dgvPrices
            // 
            this.dgvPrices.AllowUserToAddRows = false;
            this.dgvPrices.AllowUserToDeleteRows = false;
            this.dgvPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrices.Location = new System.Drawing.Point(20, 140);
            this.dgvPrices.Name = "dgvPrices";
            this.dgvPrices.RowTemplate.Height = 25;
            this.dgvPrices.Size = new System.Drawing.Size(300, 150);
            this.dgvPrices.TabIndex = 6;
            // Add two columns: "Type" (read-only) and "Price" (editable)
            System.Windows.Forms.DataGridViewTextBoxColumn colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colType.HeaderText = "Type";
            colType.Name = "colType";
            colType.ReadOnly = true;
            System.Windows.Forms.DataGridViewTextBoxColumn colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPrice.HeaderText = "Price";
            colPrice.Name = "colPrice";
            this.dgvPrices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colType, colPrice });
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(300, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Item";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ItemMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 360);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvPrices);
            this.Controls.Add(this.txtShortCode);
            this.Controls.Add(this.lblShortCode);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.cmbMenuSection);
            this.Controls.Add(this.lblMenuSection);
            this.Name = "ItemMasterForm";
            this.Text = "Item Master";
            this.Load += new System.EventHandler(this.ItemMasterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
