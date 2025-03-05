namespace BarManagementSystem
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.treeViewMenu = new System.Windows.Forms.TreeView();
            this.SuspendLayout();

            this.treeViewMenu.Location = new System.Drawing.Point(12, 12);
            this.treeViewMenu.Size = new System.Drawing.Size(360, 400);
            this.treeViewMenu.TabIndex = 0;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 421);
            this.Controls.Add(this.treeViewMenu);
            this.Text = "Menu";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TreeView treeViewMenu;
    }
}