using System;
using System.Data;
using System.Windows.Forms;

namespace restaurantManagement
{
    public partial class OrderEditForm : Form
    {
        private int? orderId; // Nullable to handle new and existing orders

        public OrderEditForm(int? orderId = null)
        {
            InitializeComponent();
            this.orderId = orderId;
            LoadMenuItems();

            if (orderId.HasValue) // Editing an existing order
            {
                LoadOrderItems();
            }
            else // Creating a new order
            {
                LoadAvailableTablesAndWaiters();
            }
        }

        private void LoadOrderItems()
        {
            if (orderId.HasValue)
            {
                DataTable dt = DatabaseHelper.GetOrderItems(orderId.Value);
                dataGridViewOrderItems.DataSource = dt;
            }
        }

        private void LoadMenuItems()
        {
            DataTable dt = DatabaseHelper.GetMenuItems();
            comboBoxMenuItems.DataSource = dt;
            comboBoxMenuItems.DisplayMember = "Name";
            comboBoxMenuItems.ValueMember = "ID";
        }

        private void LoadAvailableTablesAndWaiters()
        {
            // Load available tables
            DataTable tables = DatabaseHelper.GetAvailableTables();
            comboBoxTables.DataSource = tables;
            comboBoxTables.DisplayMember = "Number";
            comboBoxTables.ValueMember = "ID";

            // Load waiters
            DataTable waiters = DatabaseHelper.GetWaiters();
            comboBoxWaiters.DataSource = waiters;
            comboBoxWaiters.DisplayMember = "Name";
            comboBoxWaiters.ValueMember = "ID";
        }

        private void btnAddMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBoxMenuItems.SelectedValue != null && numericUpDownQuantity.Value > 0)
            {
                int menuItemId = Convert.ToInt32(comboBoxMenuItems.SelectedValue);
                int quantity = Convert.ToInt32(numericUpDownQuantity.Value);

                if (!orderId.HasValue)
                {
                    // Create a new order first
                    if (comboBoxTables.SelectedValue == null || comboBoxWaiters.SelectedValue == null)
                    {
                        MessageBox.Show("Please select a table and a waiter.");
                        return;
                    }

                    int tableId = Convert.ToInt32(comboBoxTables.SelectedValue);
                    int waiterId = Convert.ToInt32(comboBoxWaiters.SelectedValue);

                    orderId = DatabaseHelper.CreateOrder(tableId, waiterId);

                    if (!orderId.HasValue)
                    {
                        MessageBox.Show("Failed to create order.");
                        return;
                    }
                }

                // Add item to the order
                bool success = DatabaseHelper.AddMenuItemToOrder(orderId.Value, menuItemId, quantity);

                if (success)
                {
                    MessageBox.Show("Item added successfully.");
                    LoadOrderItems(); // Refresh order items
                }
                else
                {
                    MessageBox.Show("Failed to add item.");
                }
            }
            else
            {
                MessageBox.Show("Please select a menu item and enter a valid quantity.");
            }
        }

        private void btnAddMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void OrderEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
