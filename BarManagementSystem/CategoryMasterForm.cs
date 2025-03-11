using System;
using System.Data.SQLite;
using System.Linq;
    using System.Windows.Forms;

    namespace barmanagement
    {
        public partial class CategoryMasterForm : Form
        {
            // Use the connection string from your DatabaseHelper
            private readonly string connectionString = DatabaseHelper.GetConnectionString();

        public CategoryMasterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds the type from txtType to the list box when the Add button is clicked.
        /// </summary>
        private void btnAddType_Click(object sender, EventArgs e)
        {
            string typeToAdd = txtType.Text.Trim();
            if (!string.IsNullOrEmpty(typeToAdd))
            {
                // Optionally, check for duplicates:
                if (!lstTypes.Items.Contains(typeToAdd))
                {
                    lstTypes.Items.Add(typeToAdd);
                    txtType.Clear();
                    txtType.Focus();
                }
                else
                {
                    MessageBox.Show("This type has already been added.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves the new Menu Section (Category) to the database.
        /// Prevents duplicate section names.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sectionName = txtSectionName.Text.Trim();
            if (string.IsNullOrEmpty(sectionName))
            {
                MessageBox.Show("Please enter the section name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string description = txtDescription.Text.Trim();
            string types = string.Join(",", lstTypes.Items.Cast<string>());

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Check if the section name already exists
                    string checkQuery = "SELECT COUNT(*) FROM MenuSection WHERE Name = @Name";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Name", sectionName);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Section name already exists! Please use a different name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Stop execution if duplicate is found
                        }
                    }

                    // If the section name is unique, insert the new record
                    string insertQuery = "INSERT INTO MenuSection (Name, Description, Types) VALUES (@Name, @Description, @Types)";
                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", sectionName);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Types", types);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Menu Section saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields after saving
                txtSectionName.Clear();
                txtDescription.Clear();
                lstTypes.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving Menu Section: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    }
