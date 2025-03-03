using System;
using System.Data;
using System.Windows.Forms;

namespace restaurantManagement
{
    public partial class ManageOrders : Form
    {
        public ManageOrders()
        {
            InitializeComponent();
            LoadOrders();
        }

        // Load all pending orders
        private void LoadOrders()
        {
            DataTable dt = DatabaseHelper.GetOrders();
            dataGridViewOrders.DataSource = dt;
        }

        // Open Order Edit Form when user selects an order
        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells["ID"].Value);
                OrderEditForm orderEditForm = new OrderEditForm(orderId);
                orderEditForm.ShowDialog();
                LoadOrders(); // Refresh orders after editing
            }
            else
            {
                MessageBox.Show("Please select an order to edit.");
            }
        }

        // Open OrderEditForm in "Create Mode"
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            OrderEditForm orderEditForm = new OrderEditForm(); // No orderId means new order
            orderEditForm.ShowDialog();
            LoadOrders(); // Refresh orders after adding
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
