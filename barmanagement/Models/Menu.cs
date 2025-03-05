using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarManagementSystem.Models
{
    public class Menu
    {
        private int menuID;
        private int barID;
        private string name;

        public int MenuID { get { return menuID; } set { menuID = value; } }
        public int BarID { get { return barID; } set { barID = value; } }
        public string Name { get { return name; } set { name = value; } }
    }
}
