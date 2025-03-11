using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
            LoadActiveTables();
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

                        // Get the updated total price
                        string getTotalPrice = @"
                    SELECT TotalBill FROM Orders 
                    WHERE OrderID = @OrderID";

                        using (SQLiteCommand getTotalCommand = new SQLiteCommand(getTotalPrice, conn))
                        {
                            getTotalCommand.Parameters.AddWithValue("@OrderID", activeOrderId);
                            object result = getTotalCommand.ExecuteScalar();

                            if (result != null)
                            {
                                totalPriceText.Text = result.ToString();
                            }
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
            int quantity = (int)numQuantity.Value;

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

            // Check if the item with the same type already exists in the order.
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string checkItemQuery = "SELECT Quantity FROM OrderItem WHERE OrderID = @OrderID AND MenuItemID = @MenuItemID AND Type = @Type";
                    using (SQLiteCommand cmd = new SQLiteCommand(checkItemQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", activeOrderId);
                        cmd.Parameters.AddWithValue("@MenuItemID", currentMenuItemID);
                        cmd.Parameters.AddWithValue("@Type", selectedType);
                        object result = cmd.ExecuteScalar();

                        if (result != null) // Item exists, update quantity
                        {
                            int existingQuantity = Convert.ToInt32(result);
                            int newQuantity = existingQuantity + quantity;

                            string updateItemQuery = "UPDATE OrderItem SET Quantity = @NewQuantity WHERE OrderID = @OrderID AND MenuItemID = @MenuItemID AND Type = @Type";
                            using (SQLiteCommand updateCmd = new SQLiteCommand(updateItemQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
                                updateCmd.Parameters.AddWithValue("@OrderID", activeOrderId);
                                updateCmd.Parameters.AddWithValue("@MenuItemID", currentMenuItemID);
                                updateCmd.Parameters.AddWithValue("@Type", selectedType);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else // Item does not exist, insert new item
                        {
                            string insertItem = "INSERT INTO OrderItem (OrderID, MenuItemID, Type, Price, Quantity, Status) VALUES (@OrderID, @MenuItemID, @Type, @Price, @Quantity, 'Pending')";
                            using (SQLiteCommand cmdInsert = new SQLiteCommand(insertItem, conn))
                            {
                                cmdInsert.Parameters.AddWithValue("@OrderID", activeOrderId);
                                cmdInsert.Parameters.AddWithValue("@MenuItemID", currentMenuItemID);
                                cmdInsert.Parameters.AddWithValue("@Type", selectedType);
                                cmdInsert.Parameters.AddWithValue("@Price", price);
                                cmdInsert.Parameters.AddWithValue("@Quantity", quantity);
                                cmdInsert.ExecuteNonQuery();
                            }
                        }

                        // Update the total bill amount in the Orders table
                        string updateTotalQuery = @"
                    UPDATE Orders 
                    SET TotalBill = (
                        SELECT SUM(Price * Quantity) 
                        FROM OrderItem 
                        WHERE OrderID = @OrderID
                    ) 
                    WHERE OrderID = @OrderID";
                        using (SQLiteCommand updateTotalCmd = new SQLiteCommand(updateTotalQuery, conn))
                        {
                            updateTotalCmd.Parameters.AddWithValue("@OrderID", activeOrderId);
                            updateTotalCmd.ExecuteNonQuery();
                        }


                        // Get the updated total price
                        string getTotalPrice = @"
                    SELECT TotalBill FROM Orders 
                    WHERE OrderID = @OrderID";

                        using (SQLiteCommand getTotalCommand = new SQLiteCommand(getTotalPrice, conn))
                        {
                            getTotalCommand.Parameters.AddWithValue("@OrderID", activeOrderId);
                            object totalPrice = getTotalCommand.ExecuteScalar();

                            if (totalPrice != null)
                            {
                                totalPriceText.Text = totalPrice.ToString();
                            }
                        }

                    }
                }

                MessageBox.Show("Item added/updated in order successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                LoadActiveTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding/updating item in order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// Loads the list of occupied tables along with their total order amount.
        /// </summary>
        private void LoadActiveTables()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    // Query: Get active table numbers and sum up the total amount from active (ongoing) orders.
                    string query = @"
                SELECT o.TableID, 
                       COALESCE(SUM(oi.Price * oi.Quantity), 0) AS TotalAmount
                FROM Orders o
                JOIN OrderItem oi ON o.OrderID = oi.OrderID
                WHERE o.EndedAt IS NULL
                GROUP BY o.TableID";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvOccupiedTables.DataSource = dt; // Assuming a DataGridView named dgvActiveTables
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading active tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // You can call LoadOccupiedTables() from DashboardForm_Load and also after any order changes.
        private void DashboardForm_Load_Override()
        {
            // This can be used to refresh the occupied tables list.
            LoadActiveTables();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            if (activeOrderId == -1)
            {
                MessageBox.Show("No active order to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Fetch order items
                    string query = @"
                SELECT mi.Name AS ItemName, oi.Type, oi.Price, oi.Quantity, (oi.Price * oi.Quantity) AS Total
                FROM OrderItem oi
                JOIN MenuItem mi ON oi.MenuItemID = mi.MenuItemId
                WHERE oi.OrderID = @OrderID";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", activeOrderId);
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No items found for this order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Fetch total amount
                        decimal totalAmount = 0;
                        using (SQLiteCommand totalCmd = new SQLiteCommand("SELECT TotalBill FROM Orders WHERE OrderID = @OrderID", conn))
                        {
                            totalCmd.Parameters.AddWithValue("@OrderID", activeOrderId);
                            object result = totalCmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                totalAmount = Convert.ToDecimal(result);
                            }
                        }

                        // Ensure PDF Path
                        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Bill_Order_{activeOrderId}.pdf");

                        using (FileStream stream = new FileStream(filePath, FileMode.Create))
                        {
                            Document document = new Document(PageSize.A4);
                            PdfWriter.GetInstance(document, stream);
                            document.Open();

                            // **Fix: Ensure Font is Valid**
                            iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16f) ?? new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD);
                            Paragraph title = new Paragraph("Bill Receipt", titleFont)
                            {
                                Alignment = Element.ALIGN_CENTER,
                                SpacingAfter = 20f
                            };
                            document.Add(title);

                            // Create Table
                            PdfPTable table = new PdfPTable(5);
                            table.WidthPercentage = 100;
                            table.SetWidths(new float[] { 30f, 20f, 15f, 10f, 15f });

                            // Table Headers
                            string[] headers = { "Item Name", "Type", "Price", "Qty", "Total" };
                            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f) ?? new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD);

                            foreach (var header in headers)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(header, headerFont))
                                {
                                    HorizontalAlignment = Element.ALIGN_CENTER,
                                    BackgroundColor = new BaseColor(200, 200, 200)
                                };
                                table.AddCell(cell);
                            }

                            // **Fix: Handle Nulls in Row Data**
                            iTextSharp.text.Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 11f) ?? new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11f);

                            foreach (DataRow row in dt.Rows)
                            {
                                table.AddCell(new Phrase(Convert.ToString(row["ItemName"]) ?? "", cellFont));
                                table.AddCell(new Phrase(Convert.ToString(row["Type"]) ?? "", cellFont));
                                table.AddCell(new Phrase(Convert.ToString(row["Price"]) ?? "", cellFont));
                                table.AddCell(new Phrase(Convert.ToString(row["Quantity"]) ?? "", cellFont));
                                table.AddCell(new Phrase(Convert.ToString(row["Total"]) ?? "", cellFont));
                            }

                            document.Add(table);

                            // Total Amount
                            iTextSharp.text.Font totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14f) ?? new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, iTextSharp.text.Font.BOLD);
                            Paragraph totalParagraph = new Paragraph($"\nTotal Amount: ₹{totalAmount}", totalFont)
                            {
                                Alignment = Element.ALIGN_RIGHT
                            };
                            document.Add(totalParagraph);

                            document.Close();
                        }

                        // Open PDF Automatically
                        Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });

                        MessageBox.Show("Bill generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating bill: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvActiveTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                int tableID = Convert.ToInt32(dgvOccupiedTables.Rows[e.RowIndex].Cells["TableID"].Value);
                txtTableNumber.Text = tableID.ToString();
                btnLoadTable_Click(null, null);
            }
        }

        private void btnPaid_Click(object sender, EventArgs e)
{
    if (activeOrderId == -1)
    {
        MessageBox.Show("No active order to complete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    try
    {
        using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        {
            conn.Open();

            // Update the order status to mark it as completed
            string updateOrderQuery = @"
                UPDATE Orders 
                SET EndedAt = CURRENT_TIMESTAMP 
                WHERE OrderID = @OrderID";

            using (SQLiteCommand cmd = new SQLiteCommand(updateOrderQuery, conn))
            {
                cmd.Parameters.AddWithValue("@OrderID", activeOrderId);
                cmd.ExecuteNonQuery();
            }
        }

        // Reset active order
        activeOrderId = -1;
        dgvActiveOrders.DataSource = null;  // Clear the grid
        txtPrice.Text = "0";  // Reset total price
                LoadActiveTables();

        MessageBox.Show("Order completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error completing the order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void lblTotalPrice_Click(object sender, EventArgs e)
        {

        }
    }
}
