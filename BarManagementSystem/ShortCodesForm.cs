using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace barmanagement
{
    public partial class ShortcodesForm : Form
    {
        // Get the connection string from the DatabaseHelper.
        private readonly string connectionString = DatabaseHelper.GetConnectionString();

        public ShortcodesForm()
        {
            InitializeComponent();
        }

        private void ShortcodesForm_Load(object sender, EventArgs e)
        {
            LoadShortcodes();
        }

        /// <summary>
        /// Loads all MenuItem shortcodes along with their names and displays them in the DataGridView.
        /// </summary>
        private void LoadShortcodes()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    // Query to retrieve Name and ShortCode from MenuItem.
                    string query = "SELECT Name, ShortCode FROM MenuItem";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvShortcodes.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading shortcodes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
