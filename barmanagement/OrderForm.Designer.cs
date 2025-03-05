namespace BarManagementSystem
{
    partial class OrderForm
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
            this.lblTable = new System.Windows.Forms.Label();
            this.treeViewMenu = new System.Windows.Forms.TreeView();
            this.listBoxOrderItems = new System.Windows.Forms.ListBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTable.Location = new System.Drawing.Point(12, 12);
            this.lblTable.Size = new System.Drawing.Size(100, 23);
            this.lblTable.Text = "Table";

            this.treeViewMenu.Location = new System.Drawing.Point(12, 40);
            this.treeViewMenu.Size = new System.Drawing.Size(200, 300);
            this.treeViewMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewMenu_NodeMouseDoubleClick);

            this.listBoxOrderItems.Location = new System.Drawing.Point(220, 40);
            this.listBoxOrderItems.Size = new System.Drawing.Size(200, 300);

            this.lblTotal.Location = new System.Drawing.Point(220, 350);
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.Text = "Total: $0.00";

            this.btnPlaceOrder.Location = new System.Drawing.Point(330, 350);
            this.btnPlaceOrder.Size = new System.Drawing.Size(90, 30);
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 390);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.treeViewMenu);
            this.Controls.Add(this.listBoxOrderItems);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnPlaceOrder);
            this.Text = "Place Order";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.TreeView treeViewMenu;
        private System.Windows.Forms.ListBox listBoxOrderItems;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPlaceOrder;
    }
}