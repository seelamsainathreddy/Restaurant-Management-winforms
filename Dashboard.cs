using System;
using System.Windows.Forms;

namespace restaurantManagement
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        // Load the specified form inside panelContent
        private void LoadForm(Form form)
        {
            panelContent.Controls.Clear(); // Remove any existing form
            form.TopLevel = false; // Make it a child control
            form.FormBorderStyle = FormBorderStyle.None; // Remove borders
            form.Dock = DockStyle.Fill; // Make it fill the panel
            panelContent.Controls.Add(form);
            form.Show();
        }

        // Load ManageOrders form
        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            LoadForm(new ManageOrders());
        }

        // Load ManageTables form
        private void btnManageTables_Click(object sender, EventArgs e)
        {
            LoadForm(new ManageTables()); // Assuming you have a ManageTables form
        }

        // Sign out (Exit application)
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Ensure application closes when dashboard is closed
        }
    }
}
