// MenuForm.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BarManagementSystem.DataAccess;
using BarManagementSystem.Models;
using MenuItem = BarManagementSystem.Models.MenuItem;

namespace BarManagementSystem
{
    public partial class MenuForm : Form
    {
        private DatabaseContext dbContext = new DatabaseContext();

        public MenuForm()
        {
            InitializeComponent();
            LoadMenu();
        }

        private void LoadMenu()
        {
            treeViewMenu.Nodes.Clear();
            List<MenuSection> sections = dbContext.GetMenuSections(1); // Assuming MenuID = 1
            foreach (MenuSection section in sections)
            {
                TreeNode sectionNode = treeViewMenu.Nodes.Add(section.Name + (string.IsNullOrEmpty(section.Types) ? "" : " (" + section.Types + ")"));
                List<MenuItem> items = dbContext.GetMenuItems(section.SectionID);
                foreach (MenuItem item in items)
                {
                    if (item.IsAvailable)
                    {
                        sectionNode.Nodes.Add(item.Name + (string.IsNullOrEmpty(item.Types) ? "" : " (" + item.Types + " - " + item.Prices + ")"));
                    }
                }
            }
            treeViewMenu.ExpandAll();
        }
    }
}