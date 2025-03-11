using System;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace barmanagement
{
    public partial class DashboardForm : Form
    {
        private readonly string connectionString = DatabaseHelper.GetConnectionString();
        private int activeOrderId = -1; // Active order for the selected table

        // Variables to store current item details after search.
        private int currentMenuItemID = -1;
        private string currentPricesString = "";
        private string[] currentPricesArray = null;

        public DashboardForm()
        {
            InitializeComponent();
            LoadOccupiedTables();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Optionally, load initial data.
        }

        // Nav Bar event handlers:
        private void categoryMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryMasterForm form = new CategoryMasterForm();
            form.Show();
        }

        private void tableMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableMasterForm form = new TableMasterForm();
            form.Show();
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemMasterForm form = new ItemMasterForm();
            form.Show();
        }

        /// <summary>
        /// Loads the active order for the entered table number.
        /// </summary>
        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            dgvActiveOrders.DataSource = null;
            activeOrderId = -1;

            int tableNumber;
            if (!int.TryParse(txtTableNumber.Text.Trim(), out tableNumber))
            {
                MessageBox.Show("Please enter a valid table number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    // Check for an active order (EndedAt IS NULL) for the table.
                    string query = "SELECT OrderID FROM Orders WHERE TableID = @TableNumber AND EndedAt IS NULL";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TableNumber", tableNumber);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            activeOrderId = Convert.ToInt32(result);
                        }
                    }

                    if (activeOrderId != -1)
                    {
                        // Load order items.
                        string itemsQuery = @"SELECT oi.MenuItemID, mi.Name AS ItemName, oi.Type, oi.Price, oi.Quantity 
                                              FROM OrderItem oi
                                              JOIN MenuItem mi ON oi.MenuItemID = mi.MenuItemId
                                              WHERE oi.OrderID = @OrderID";
                        using (SQLiteCommand cmd = new SQLiteCommand(itemsQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@OrderID", activeOrderId);
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvActiveOrders.DataSource = dt;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No active orders for this table. The table is empty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading table orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisplayShortcodes_Click(object sender, EventArgs e)
        {
            // Open the ShortcodesForm to display all item shortcodes and names.
            ShortcodesForm form = new ShortcodesForm();
            form.ShowDialog();
        }

        /// <summary>
        /// Searches for an item by its code (ShortCode) and loads its details.
        /// </summary>
        private void btnSearchItem_Click(object sender, EventArgs e)
        {
            string itemCode = txtItemCode.Text.Trim();
            if (string.IsNullOrEmpty(itemCode))
            {
                MessageBox.Show("Please enter an item code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    // Query MenuItem by ShortCode.
                    string query = "SELECT MenuItemId, Name, SectionId, Prices FROM MenuItem WHERE ShortCode = @ShortCode";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ShortCode", itemCode);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currentMenuItemID = Convert.ToInt32(reader["MenuItemId"]);
                                txtItemName.Text = reader["Name"].ToString();
                                currentPricesString = reader["Prices"].ToString(); // Comma-separated prices.
                                Console.WriteLine($"current price string before reading is {currentPricesString}");


                            }
                            else
                            {
                                MessageBox.Show("Item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Retrieve the types from the MenuSection for the item's SectionId.
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT Types FROM MenuSection WHERE SectionId = (SELECT SectionId FROM MenuItem WHERE MenuItemId = @MenuItemId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@MenuItemId", currentMenuItemID);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string typesString = result.ToString();
                            cmbType.Items.Clear();
                            var types = typesString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(t => t.Trim());
                            foreach (var type in types)
                            {
                                cmbType.Items.Add(type);
                            }
                            if (cmbType.Items.Count > 0)
                                cmbType.SelectedIndex = 0;
                        }
                    }

                    // Parse the Prices string into an array.
                    if (!string.IsNullOrEmpty(currentPricesString))

                    {
                        currentPricesArray = currentPricesString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                                 .Select(p => p.Trim())
                                                                 .ToArray();
                    }
                    else
                    {
                        currentPricesArray = new string[0];
                    }
                    UpdatePriceDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePriceDisplay();
        }

        private void UpdatePriceDisplay()
        {
            if (cmbType.SelectedIndex >= 0 && currentPricesArray != null && currentPricesArray.Length > cmbType.SelectedIndex)

            {
                Console.WriteLine("Index: " + cmbType.SelectedIndex + ", Prices: " + string.Join(", ", currentPricesArray));
                txtPrice.Text = currentPricesArray[cmbType.SelectedIndex];
            }
            else
            {
                Console.WriteLine($"Invalid index or prices array.{currentPricesArray}");
                txtPrice.Text = "0";
            }
        }

        /// <summary>
        /// Adds the selected item to the order. Creates a new order if none exists.
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int tableNumber;
            if (!int.TryParse(txtTableNumber.Text.Trim(), out tableNumber))
            {
                MessageBox.Show("Please enter a valid table number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (currentMenuItemID == -1)
            {
                MessageBox.Show("Please search and select a valid item first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedType = cmbType.SelectedItem.ToString();
            decimal price;
            if (!decimal.TryParse(txtPrice.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out price))
                price = 0;
            int quantityToAdd = (int)numQuantity.Value;

            // If no active order, create one.
            if (activeOrderId == -1)
            {
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        string insertOrder = "INSERT INTO Orders (TableID, TotalBill, Paid, CreatedAt) VALUES (@TableID, 0, 0, CURRENT_TIMESTAMP)";
                        using (SQLiteCommand cmd = new SQLiteCommand(insertOrder, conn))
                        {
                            cmd.Parameters.AddWithValue("@TableID", tableNumber);
                            cmd.ExecuteNonQuery();
                        }
                        using (SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid()", conn))
                        {
                            activeOrderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating new order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Check if the item and type already exist in the order
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string checkExistingItem = "SELECT Quantity FROM OrderItem WHERE OrderID = @OrderID AND MenuItemID = @MenuItemID AND Type = @Type";
                    using (SQLiteCommand cmd = new SQLiteCommand(checkExistingItem, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", activeOrderId);
                        cmd.Parameters.AddWithValue("@MenuItemID", currentMenuItemID);
                        cmd.Parameters.AddWithValue("@Type", selectedType);
                        object existingQuantity = cmd.ExecuteScalar();

                        if (existingQuantity != null)
                        {
                            // Update the quantity if the item already exists
                            int updatedQuantity = Convert.ToInt32(existingQuantity) + quantityToAdd;
                            string updateQuery = "UPDATE OrderItem SET Quantity = @UpdatedQuantity WHERE OrderID = @OrderID AND MenuItemID = @MenuItemID AND Type = @Type";
                            using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@UpdatedQuantity", updatedQuantity);
                                updateCmd.Parameters.AddWithValue("@OrderID", activeOrderId);
                                updateCmd.Parameters.AddWithValue("@MenuItemID", currentMenuItemID);
                                updateCmd.Parameters.AddWithValue("@Type", selectedType);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Insert a new row if the item does not exist
                            string insertItem = "INSERT INTO OrderItem (OrderID, MenuItemID, Type, Price, Quantity, Status) VALUES (@OrderID, @MenuItemID, @Type, @Price, @Quantity, 'Pending')";
                            using (SQLiteCommand insertCmd = new SQLiteCommand(insertItem, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@OrderID", activeOrderId);
                                insertCmd.Parameters.AddWithValue("@MenuItemID", currentMenuItemID);
                                insertCmd.Parameters.AddWithValue("@Type", selectedType);
                                insertCmd.Parameters.AddWithValue("@Price", price);
                                insertCmd.Parameters.AddWithValue("@Quantity", quantityToAdd);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                MessageBox.Show("Item added/updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the active orders display.
                btnLoadTable_Click(null, null);

                // Clear the item adder fields.
                txtItemCode.Clear();
                txtItemName.Clear();
                cmbType.Items.Clear();
                txtPrice.Clear();
                numQuantity.Value = 1;
                currentMenuItemID = -1;
                currentPricesString = "";
                currentPricesArray = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding/updating item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Loads the list of occupied tables along with their total order amount.
        /// </summary>
        private void LoadOccupiedTables()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    // Query: for each table that is marked occupied, sum up the order items (price*quantity) from active (unpaid) orders.
                    // Using COALESCE to default to 0 if there are no order items.
                    string query = @"
                        SELECT t.TableNumber, 
                               COALESCE(
                                  (SELECT SUM(oi.Price * oi.Quantity) 
                                   FROM Orders o 
                                   JOIN OrderItem oi ON o.OrderID = oi.OrderID 
                                   WHERE o.TableID = t.TableNumber AND o.Paid = 0),
                                  0
                               ) AS TotalAmount
                        FROM TableInfo t
                        WHERE t.OccupiedStatus = 1";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvOccupiedTables.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading occupied tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // You can call LoadOccupiedTables() from DashboardForm_Load and also after any order changes.
        private void DashboardForm_Load_Override()
        {
            // This can be used to refresh the occupied tables list.
            LoadOccupiedTables();
        }

        // Navigation Bar event handlers.
        private void CategoryMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryMasterForm form = new CategoryMasterForm();
            form.Show();
        }

        private void TableMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableMasterForm form = new TableMasterForm();
            form.Show();
        }

        private void ItemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemMasterForm form = new ItemMasterForm();
            form.Show();
        }
    }
}
