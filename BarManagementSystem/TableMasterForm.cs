using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace barmanagement
{
    public partial class TableMasterForm : Form
    {
        public TableMasterForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableNumber.Text) || cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter a table number and select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tableNumber;
            if (!int.TryParse(txtTableNumber.Text, out tableNumber))
            {
                MessageBox.Show("Table number must be a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string category = cmbCategory.SelectedItem.ToString();

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=bar_management.db;Version=3;"))
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM TableInfo WHERE TableNumber = @TableNumber";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@TableNumber", tableNumber);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Table number already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string insertQuery = "INSERT INTO TableInfo (TableNumber, OccupiedStatus, Category) VALUES (@TableNumber, 0, @Category)";
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@TableNumber", tableNumber);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Table added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTableNumber.Clear();
                cmbCategory.SelectedIndex = -1;
            }
        }
    }
}
