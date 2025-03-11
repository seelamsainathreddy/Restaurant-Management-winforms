namespace barmanagement
{
    partial class ShortcodesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvShortcodes;

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
            this.dgvShortcodes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShortcodes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShortcodes
            // 
            this.dgvShortcodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShortcodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShortcodes.Location = new System.Drawing.Point(0, 0);
            this.dgvShortcodes.Name = "dgvShortcodes";
            this.dgvShortcodes.RowTemplate.Height = 25;
            this.dgvShortcodes.Size = new System.Drawing.Size(400, 300);
            this.dgvShortcodes.TabIndex = 0;
            // 
            // ShortcodesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.dgvShortcodes);
            this.Name = "ShortcodesForm";
            this.Text = "Item Shortcodes";
            this.Load += new System.EventHandler(this.ShortcodesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShortcodes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
