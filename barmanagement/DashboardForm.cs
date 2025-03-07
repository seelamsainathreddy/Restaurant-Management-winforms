// DashboardForm.cs
using System;
using System.Windows.Forms;
using BarManagementSystem.DataAccess;
using BarManagementSystem.Models;

namespace BarManagementSystem
{
    public partial class DashboardForm : Form
    {
        private DatabaseContext dbContext;
        private OrderItemService orderItemService;
        private int currentTableId;

        public DashboardForm()
        {
            InitializeComponent();
            dbContext = new DatabaseContext();
            orderItemService = new OrderItemService(dbContext);
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LoadOrderItems();
        }

        private void LoadOrderItems()
        {
            if (int.TryParse(textBox1.Text, out int tableId))
            {
                currentTableId = tableId;
                var orderItems = orderItemService.GetOrderItems(tableId);
                dataGridViewOrderItems.Rows.Clear();
                foreach (var item in orderItems)
                {
                    dataGridViewOrderItems.Rows.Add(item.MenuItem.Name, item.SelectedType, item.Quantity, "", item.Price, item.Amount, item.KOT);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid table number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripDropDownButtonMaster_Click(object sender, EventArgs e)
        {
            // Optional: Handle dropdown button click if needed
        }

        private void toolStripMenuItemCategoryMaster_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Category Master functionality to be implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItemTableMaster_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Table Master functionality to be implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItemItemMaster_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Item Master functionality to be implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButtonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrderItems.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewOrderItems.SelectedRows[0].Index;
                var row = dataGridViewOrderItems.Rows[selectedIndex];
                var item = new OrderLineItem
                {
                    OrderId = currentTableId,
                    ItemId = orderItemService.GetOrderItems(currentTableId)[selectedIndex].ItemId,
                    MenuItem = orderItemService.GetOrderItems(currentTableId)[selectedIndex].MenuItem,
                    SelectedType = row.Cells["SelectedType"].Value?.ToString(),
                    Quantity = int.Parse(row.Cells["Quantity"].Value?.ToString() ?? "1"),
                    Price = row.Cells["Price"].Value?.ToString(),
                    Amount = row.Cells["Amount"].Value?.ToString(),
                    KOT = row.Cells["KOT"].Value?.ToString()
                };
                orderItemService.DeleteOrderItem(item);
                dataGridViewOrderItems.Rows.RemoveAt(selectedIndex);
                MessageBox.Show("Item deleted from order.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrderItems.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewOrderItems.SelectedRows[0].Index;
                dataGridViewOrderItems.CurrentCell = dataGridViewOrderItems.Rows[selectedIndex].Cells[1]; // Focus on SelectedType
                dataGridViewOrderItems.BeginEdit(true);
                MessageBox.Show("Edit the selected item (e.g., change Type or Quantity) and press Enter to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select an item to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewOrderItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) // SelectedType column
            {
                var row = dataGridViewOrderItems.Rows[e.RowIndex];
                var menuItem = orderItemService.GetOrderItems(currentTableId)[e.RowIndex].MenuItem;
                string selectedType = row.Cells["SelectedType"].Value?.ToString();
                string[] types = menuItem.Types.Split(',');
                string[] prices = menuItem.Prices.Split(',');
                int index = Array.IndexOf(types, selectedType);
                if (index >= 0 && index < prices.Length)
                {
                    row.Cells["Price"].Value = prices[index].Replace("rs", "").Trim();
                    if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int quantity))
                    {
                        row.Cells["Amount"].Value = (quantity * double.Parse(prices[index].Replace("rs", "").Trim())).ToString("F2");
                    }
                }
            }
            else if (e.ColumnIndex == 2) // Quantity column
            {
                var row = dataGridViewOrderItems.Rows[e.RowIndex];
                if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int quantity) && double.TryParse(row.Cells["Price"].Value?.ToString(), out double price))
                {
                    row.Cells["Amount"].Value = (quantity * price).ToString("F2");
                }
            }

            var item = new OrderLineItem
            {
                OrderId = currentTableId,
                ItemId = orderItemService.GetOrderItems(currentTableId)[e.RowIndex].ItemId,
                MenuItem = orderItemService.GetOrderItems(currentTableId)[e.RowIndex].MenuItem,
                SelectedType = dataGridViewOrderItems.Rows[e.RowIndex].Cells["SelectedType"].Value?.ToString(),
                Quantity = int.Parse(dataGridViewOrderItems.Rows[e.RowIndex].Cells["Quantity"].Value?.ToString() ?? "1"),
                Price = dataGridViewOrderItems.Rows[e.RowIndex].Cells["Price"].Value?.ToString(),
                Amount = dataGridViewOrderItems.Rows[e.RowIndex].Cells["Amount"].Value?.ToString(),
                KOT = dataGridViewOrderItems.Rows[e.RowIndex].Cells["KOT"].Value?.ToString()
            };
            orderItemService.UpdateOrderItem(item);
            MessageBox.Show("Item updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optional: Handle label click if needed
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadOrderItems();
        }

        private void dataGridViewOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}