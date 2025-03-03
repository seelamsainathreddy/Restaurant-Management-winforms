namespace restaurantManagement
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnManageTables;
        private System.Windows.Forms.Button btnManageOrders;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Panel panelContent; // Right-side panel for forms

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
            panelSidebar = new Panel();
            btnManageTables = new Button();
            btnManageOrders = new Button();
            btnSignOut = new Button();
            panelContent = new Panel();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(50, 50, 50);
            panelSidebar.Controls.Add(btnManageTables);
            panelSidebar.Controls.Add(btnManageOrders);
            panelSidebar.Controls.Add(btnSignOut);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(200, 474);
            panelSidebar.TabIndex = 0;
            // 
            // btnManageTables
            // 
            btnManageTables.BackColor = Color.FromArgb(70, 70, 70);
            btnManageTables.Dock = DockStyle.Top;
            btnManageTables.FlatStyle = FlatStyle.Flat;
            btnManageTables.ForeColor = Color.White;
            btnManageTables.Location = new Point(0, 50);
            btnManageTables.Name = "btnManageTables";
            btnManageTables.Size = new Size(200, 50);
            btnManageTables.TabIndex = 0;
            btnManageTables.Text = "Manage Tables";
            btnManageTables.UseVisualStyleBackColor = false;
            btnManageTables.Click += btnManageTables_Click;
            // 
            // btnManageOrders
            // 
            btnManageOrders.BackColor = Color.FromArgb(70, 70, 70);
            btnManageOrders.Dock = DockStyle.Top;
            btnManageOrders.FlatStyle = FlatStyle.Flat;
            btnManageOrders.ForeColor = Color.White;
            btnManageOrders.Location = new Point(0, 0);
            btnManageOrders.Name = "btnManageOrders";
            btnManageOrders.Size = new Size(200, 50);
            btnManageOrders.TabIndex = 1;
            btnManageOrders.Text = "Manage Orders";
            btnManageOrders.UseVisualStyleBackColor = false;
            btnManageOrders.Click += btnManageOrders_Click;
            // 
            // btnSignOut
            // 
            btnSignOut.BackColor = Color.Red;
            btnSignOut.Dock = DockStyle.Bottom;
            btnSignOut.FlatStyle = FlatStyle.Flat;
            btnSignOut.ForeColor = Color.White;
            btnSignOut.Location = new Point(0, 424);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Size = new Size(200, 50);
            btnSignOut.TabIndex = 2;
            btnSignOut.Text = "Sign Out";
            btnSignOut.UseVisualStyleBackColor = false;
            btnSignOut.Click += btnSignOut_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(603, 474);
            panelContent.TabIndex = 1;
            // 
            // Dashboard
            // 
            ClientSize = new Size(803, 474);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            FormClosed += Dashboard_FormClosed;
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
