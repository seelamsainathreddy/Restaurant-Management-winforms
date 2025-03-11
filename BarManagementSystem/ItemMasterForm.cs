using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace barmanagement
{
    public partial class ItemMasterForm : Form
    {
        // Retrieve the connection string from DatabaseHelper.
        private readonly string connectionString = DatabaseHelper.GetConnectionString();

        public ItemMasterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the form loads, load existing MenuSections (using their unique names) into the dropdown.
        /// </summary>
        private void ItemMasterForm_Load(object sender, EventArgs e)
        {
            LoadMenuSections();
        }

        /// <summary>
        /// Loads existing menu sections into cmbMenuSection with the section Name as the Value.
        /// </summary>
        private void LoadMenuSections()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Name FROM MenuSection"; // Section names are unique.
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbMenuSection.DataSource = dt;
                        cmbMenuSection.DisplayMember = "Name";
                        cmbMenuSection.ValueMember = "Name"; // Using the Name as the unique value.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu sections: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// When a menu section is selected, populate dgvPrices with types and default price 0.
        /// This queries the database using the selected section name.
        /// </summary>
        private void cmbMenuSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPrices.Rows.Clear();

            if (cmbMenuSection.SelectedValue == null)
                return;

            string selectedSectionName = cmbMenuSection.SelectedValue.ToString();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    // Retrieve the types for the selected section.
                    string query = "SELECT Types FROM MenuSection WHERE Name = @Name";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", selectedSectionName);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string typesString = result.ToString();
                            // Split comma-separated types.
                            var types = typesString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(t => t.Trim());
                            foreach (var type in types)
                            {
                                dgvPrices.Rows.Add(type, "0");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gathers entered data and saves a new Item into the MenuItem table.
        /// Prices for each type are concatenated into a comma-separated string.
        /// The SectionId is retrieved by querying the MenuSection table using the unique Name.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text.Trim();
            string shortCode = txtShortCode.Text.Trim();

            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(shortCode))
            {
                MessageBox.Show("Please enter both Item Name and Short Code.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Build a comma-separated string of prices.
            string prices = "";
            foreach (DataGridViewRow row in dgvPrices.Rows)
            {
                if (!row.IsNewRow)
                {
                    string priceVal = row.Cells["colPrice"].Value?.ToString();
                    if (string.IsNullOrWhiteSpace(priceVal))
                    {
                        priceVal = "0"; // Default to 0 if empty.
                    }
                    prices += priceVal + ",";
                }
            }
            if (prices.EndsWith(","))
                prices = prices.Substring(0, prices.Length - 1);

            // Retrieve the SectionId using the selected section name.
            string selectedSectionName = cmbMenuSection.SelectedValue.ToString();
            int sectionId = 0;
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT SectionId FROM MenuSection WHERE Name = @Name";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", selectedSectionName);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            sectionId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Selected Menu Section not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving SectionId: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO MenuItem (SectionId, Name, ShortCode, Prices) VALUES (@SectionId, @Name, @ShortCode, @Prices)";
                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@SectionId", sectionId);
                        cmd.Parameters.AddWithValue("@Name", itemName);
                        cmd.Parameters.AddWithValue("@ShortCode", shortCode);
                        cmd.Parameters.AddWithValue("@Prices", prices);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Item saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtItemName.Clear();
                txtShortCode.Clear();
                dgvPrices.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
