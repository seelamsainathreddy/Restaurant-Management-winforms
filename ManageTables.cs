using System;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;  // Import Debugging

namespace restaurantManagement
{
    public partial class ManageTables : Form
    {
        public ManageTables()
        {
            InitializeComponent();
            LoadTables();
        }

        // Load tables from the database
        private void LoadTables()
        {
            DataTable dt = DatabaseHelper.GetTables();

            if (dt != null && dt.Rows.Count > 0)
            {
                dataGridViewTables.DataSource = null;
                dataGridViewTables.DataSource = dt;
                dataGridViewTables.Refresh();

                Debug.WriteLine("✅ Tables loaded successfully!");
            }
            else
            {
                Debug.WriteLine("⚠️ No tables found in database!");
            }
        }

        // Add a new table
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("🖱️ Button Clicked!");
            string tableNumber = txtTableNumber.Text;
            int capacity = (int)numCapacity.Value;

            if (!string.IsNullOrEmpty(tableNumber) && capacity > 0)
            {
                bool added = DatabaseHelper.AddTable(tableNumber, capacity);
                if (added)
                {
                    Debug.WriteLine("✅ Table added successfully.");
                    LoadTables();
                }
                else
                {
                    Debug.WriteLine("❌ Table number already exists. Choose a different number.");
                }
            }
            else
            {
                Debug.WriteLine("⚠️ Please enter a valid table number and capacity.");
            }
        }

        // Change the status of a selected table (Available <-> Occupied)
        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dataGridViewTables.SelectedRows.Count > 0)
            {
                int tableId = Convert.ToInt32(dataGridViewTables.SelectedRows[0].Cells["ID"].Value);
                string currentStatus = dataGridViewTables.SelectedRows[0].Cells["Status"].Value.ToString();
                string newStatus = currentStatus == "Available" ? "Occupied" : "Available";

                DatabaseHelper.ChangeTableStatus(tableId, newStatus);
                LoadTables();

                Debug.WriteLine($"🔄 Table {tableId} status changed to {newStatus}.");
            }
            else
            {
                Debug.WriteLine("⚠️ Please select a table to change status.");
            }
        }

        // Delete the selected table
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (dataGridViewTables.SelectedRows.Count > 0)
            {
                int tableId = Convert.ToInt32(dataGridViewTables.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    DatabaseHelper.DeleteTable(tableId);
                    Debug.WriteLine($"🗑️ Table {tableId} deleted successfully.");
                    LoadTables();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"❌ Error: {ex.Message}");
                }
            }
            else
            {
                Debug.WriteLine("⚠️ Please select a table to delete.");
            }
        }

        private void numCapacity_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("🔢 Capacity value changed.");
        }

        private void dataGridViewTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTableNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelCenter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
