namespace restaurantManagement
{
    partial class ManageOrders
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewOrders;
        private Button btnEditOrder;
        private Button btnAddOrder;
        private Panel panelButtons;

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
            dataGridViewOrders = new DataGridView();
            btnEditOrder = new Button();
            btnAddOrder = new Button();
            panelButtons = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Dock = DockStyle.Fill;
            dataGridViewOrders.Location = new Point(0, 0);
            dataGridViewOrders.MultiSelect = false;
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.RowHeadersWidth = 51;
            dataGridViewOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrders.Size = new Size(1284, 643);
            dataGridViewOrders.TabIndex = 0;
            // 
            // btnEditOrder
            // 
            btnEditOrder.Location = new Point(19, 13);
            btnEditOrder.Margin = new Padding(10);
            btnEditOrder.Name = "btnEditOrder";
            btnEditOrder.Size = new Size(120, 40);
            btnEditOrder.TabIndex = 0;
            btnEditOrder.Text = "Edit Order";
            btnEditOrder.Click += btnEditOrder_Click;
            // 
            // btnAddOrder
            // 
            btnAddOrder.Location = new Point(169, 13);
            btnAddOrder.Margin = new Padding(10);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(150, 40);
            btnAddOrder.TabIndex = 1;
            btnAddOrder.Text = "Add New Order";
            btnAddOrder.Click += btnAddOrder_Click;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.LightGray;
            panelButtons.Controls.Add(btnEditOrder);
            panelButtons.Controls.Add(btnAddOrder);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 643);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(10);
            panelButtons.Size = new Size(1284, 60);
            panelButtons.TabIndex = 1;
            // 
            // ManageOrders
            // 
            ClientSize = new Size(1284, 703);
            Controls.Add(dataGridViewOrders);
            Controls.Add(panelButtons);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManageOrders";
            Text = "Manage Orders";
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
