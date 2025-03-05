using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// OrderForm.cs

using BarManagementSystem.DataAccess;
using BarManagementSystem.Models;
using MenuItem = BarManagementSystem.Models.MenuItem;

namespace BarManagementSystem
{
    public partial class OrderForm : Form
    {
        private DatabaseContext dbContext = new DatabaseContext();
        private Table selectedTable;
        private Order currentOrder;

        public OrderForm(Table table)
        {
            InitializeComponent();
            selectedTable = table;
            currentOrder = new Order();
            currentOrder.TableID = selectedTable.TableID;
            currentOrder.Items = new List<MenuItem>();
            lblTable.Text = "Table " + selectedTable.TableID;
            LoadMenu();
        }

        private void LoadMenu()
        {
            treeViewMenu.Nodes.Clear();
            List<MenuSection> sections = dbContext.GetMenuSections(1); // Assuming MenuID = 1
            foreach (MenuSection section in sections)
            {
                TreeNode sectionNode = treeViewMenu.Nodes.Add(section.Name);
                List<MenuItem> items = dbContext.GetMenuItems(section.SectionID);
                foreach (MenuItem item in items)
                {
                    if (item.IsAvailable)
                    {
                        sectionNode.Nodes.Add(item.Name);
                    }
                }
            }
            treeViewMenu.ExpandAll();
        }

        private void treeViewMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null) // Item node
            {
                List<MenuSection> sections = dbContext.GetMenuSections(1);
                MenuSection selectedSection = null;
                foreach (MenuSection section in sections)
                {
                    if (section.Name == e.Node.Parent.Text)
                    {
                        selectedSection = section;
                        break;
                    }
                }
                if (selectedSection != null)
                {
                    List<MenuItem> items = dbContext.GetMenuItems(selectedSection.SectionID);
                    MenuItem selectedItem = null;
                    foreach (MenuItem item in items)
                    {
                        if (item.Name == e.Node.Text)
                        {
                            selectedItem = item;
                            break;
                        }
                    }
                    if (selectedItem != null)
                    {
                        currentOrder.Items.Add(selectedItem);
                        listBoxOrderItems.Items.Add(selectedItem.Name + (string.IsNullOrEmpty(selectedItem.Types) ? "" : " (" + selectedItem.Types.Split(new char[] { ',' })[0] + ")"));
                        UpdateTotal();
                    }
                }
            }
        }

        private void UpdateTotal()
        {
            double total = 0;
            foreach (MenuItem item in currentOrder.Items)
            {
                string[] prices = item.Prices.Split(new char[] { ',' });
                if (prices.Length > 0)
                {
                    double price;
                    if (double.TryParse(prices[0].Trim(), out price))
                    {
                        total += price;
                    }
                }
            }
            currentOrder.TotalAmount = total;
            lblTotal.Text = "Total: $" + total.ToString("F2");
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (currentOrder.Items.Count == 0)
            {
                MessageBox.Show("Please add items to the order.");
                return;
            }

            // TODO: Save order to database
            MessageBox.Show("Order placed successfully for Table " + selectedTable.TableID + "!");
            this.Close();
        }
    }
}
