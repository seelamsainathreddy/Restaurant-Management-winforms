using BarManagementSystem;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace barmanagement
{
    public partial class LoginForm : Form
    {
        // Get the connection string from your DatabaseHelper
        private readonly string connectionString = DatabaseHelper.GetConnectionString();

        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On load, retrieve the Bar name from the database and update the welcome label.
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    // Retrieve the first Bar name from the Bar table
                    string query = "SELECT Name FROM Bar LIMIT 1";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string barName = result.ToString();
                            lblWelcome.Text = $"Welcome to {barName}";
                        }
                        else
                        {
                            lblWelcome.Text = "Welcome!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Bar name: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validates the password and, if correct, opens the DashboardForm.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredPassword = txtPassword.Text.Trim();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    // Retrieve the password from the Bar table
                    string query = "SELECT Password FROM Bar LIMIT 1";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string storedPassword = result.ToString();

                            if (enteredPassword == storedPassword)
                            {
                                // Password is correct, open the DashboardForm
                                DashboardForm dashboard = new DashboardForm();
                                dashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Password incorrect!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Bar information found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
