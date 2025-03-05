using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Models/MenuItem.cs
namespace BarManagementSystem.Models
{
    public class MenuItem
    {
        private int itemID;
        private int sectionID;
        private string name;
        private string types;
        private string prices;
        private bool isAvailable;

        public int ItemID { get { return itemID; } set { itemID = value; } }
        public int SectionID { get { return sectionID; } set { sectionID = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Types { get { return types; } set { types = value; } }
        public string Prices { get { return prices; } set { prices = value; } }
        public bool IsAvailable { get { return isAvailable; } set { isAvailable = value; } }
    }
}