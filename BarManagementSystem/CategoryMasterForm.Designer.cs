namespace barmanagement
{
    partial class CategoryMasterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblSectionName;
        private System.Windows.Forms.TextBox txtSectionName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.ListBox lstTypes;
        private System.Windows.Forms.Button btnSave;

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

        private void InitializeComponent()
        {
            this.lblSectionName = new System.Windows.Forms.Label();
            this.txtSectionName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.btnAddType = new System.Windows.Forms.Button();
            this.lstTypes = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSectionName
            // 
            this.lblSectionName.AutoSize = true;
            this.lblSectionName.Location = new System.Drawing.Point(20, 20);
            this.lblSectionName.Name = "lblSectionName";
            this.lblSectionName.Size = new System.Drawing.Size(85, 15);
            this.lblSectionName.TabIndex = 0;
            this.lblSectionName.Text = "Section Name:";
            // 
            // txtSectionName
            // 
            this.txtSectionName.Location = new System.Drawing.Point(20, 40);
            this.txtSectionName.Name = "txtSectionName";
            this.txtSectionName.Size = new System.Drawing.Size(240, 23);
            this.txtSectionName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 75);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 15);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(20, 95);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(240, 60);
            this.txtDescription.TabIndex = 3;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(20, 170);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(60, 15);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Add Type:";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(20, 190);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(160, 23);
            this.txtType.TabIndex = 5;
            // 
            // btnAddType
            // 
            this.btnAddType.Location = new System.Drawing.Point(190, 190);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(70, 23);
            this.btnAddType.TabIndex = 6;
            this.btnAddType.Text = "Add";
            this.btnAddType.UseVisualStyleBackColor = true;
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
            // 
            // lstTypes
            // 
            this.lstTypes.FormattingEnabled = true;
            this.lstTypes.ItemHeight = 15;
            this.lstTypes.Location = new System.Drawing.Point(20, 230);
            this.lstTypes.Name = "lstTypes";
            this.lstTypes.Size = new System.Drawing.Size(240, 94);
            this.lstTypes.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(240, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Section";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CategoryMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 400);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstTypes);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtSectionName);
            this.Controls.Add(this.lblSectionName);
            this.Name = "CategoryMasterForm";
            this.Text = "Category Master";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
