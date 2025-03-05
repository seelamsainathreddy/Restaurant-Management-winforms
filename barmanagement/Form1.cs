using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// Form1.cs
using System;
using System.Windows.Forms;
using BarManagementSystem.DataAccess;
using BarManagementSystem.Models;

namespace BarManagementSystem
{
    public partial class Form1 : Form
    {
        private DatabaseContext dbContext = new DatabaseContext();
        private List<Table> tables;

        public Form1()
        {
            InitializeComponent();
            LoadTables();
        }

        private void LoadTables()
        {
            tables = dbContext.GetTables(1); // Assuming BarID = 1
            listBoxTables.Items.Clear();
            foreach (Table table in tables)
            {
                listBoxTables.Items.Add("Table " + table.TableID + " (Capacity: " + table.Capacity + ", " + (table.IsOccupied ? "Occupied" : "Available") + ")");
            }
        }

        private void btnViewMenu_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.ShowDialog();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a table.");
                return;
            }

            Table selectedTable = tables[listBoxTables.SelectedIndex];
            OrderForm orderForm = new OrderForm(selectedTable);
            orderForm.ShowDialog();
            LoadTables(); // Refresh table status
        }
    }
}