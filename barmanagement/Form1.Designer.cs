namespace BarManagementSystem
{
    partial class Form1
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
            this.listBoxTables = new System.Windows.Forms.ListBox();
            this.btnViewMenu = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.listBoxTables.Location = new System.Drawing.Point(12, 12);
            this.listBoxTables.Size = new System.Drawing.Size(260, 200);
            this.listBoxTables.TabIndex = 0;

            this.btnViewMenu.Location = new System.Drawing.Point(12, 220);
            this.btnViewMenu.Size = new System.Drawing.Size(120, 30);
            this.btnViewMenu.Text = "View Menu";
            this.btnViewMenu.Click += new System.EventHandler(this.btnViewMenu_Click);

            this.btnPlaceOrder.Location = new System.Drawing.Point(150, 220);
            this.btnPlaceOrder.Size = new System.Drawing.Size(120, 30);
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.listBoxTables);
            this.Controls.Add(this.btnViewMenu);
            this.Controls.Add(this.btnPlaceOrder);
            this.Text = "Bar Management System";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox listBoxTables;
        private System.Windows.Forms.Button btnViewMenu;
        private System.Windows.Forms.Button btnPlaceOrder;
    }
}