// LoginForm.cs
using System;
using System.Windows.Forms;
using barmanagement;
using BarManagementSystem.DataAccess;
using BarManagementSystem.Models;

namespace BarManagementSystem
{
    public partial class LoginForm : Form
    {
        private DatabaseContext dbContext;

        public LoginForm()
        {
            InitializeComponent();
            dbContext = new DatabaseContext();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredPassword = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please enter a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve the stored password from the Bar table (assuming BarID = 1)
            string storedPassword = GetStoredPassword(1); // BarID = 1 for demo purposes
            if (storedPassword == null)
            {
                MessageBox.Show("No bar found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Compare passwords
            if (enteredPassword == storedPassword)
            {
                // Password correct, open the main form
                DashboardForm dashBoardFrom = new DashboardForm();
                dashBoardFrom.Show();
                this.Hide(); // Hide the login form instead of closing to prevent app termination
            }
            else
            {
                MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private string GetStoredPassword(int barID)
        {
            string storedPassword = null;
            using (System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection(dbContext.connectionString))
            {
                connection.Open();
                string query = "SELECT PassWord FROM Bar WHERE BarID = @BarID";
                using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BarID", barID);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        storedPassword = result.ToString();
                    }
                }
            }
            return storedPassword;
        }

        // Expose ConnectionString for use in GetStoredPassword
        private string ConnectionString
        {
            get { return "Data Source=bar_database.sqlite;Version=3;"; }
        }
    }
}