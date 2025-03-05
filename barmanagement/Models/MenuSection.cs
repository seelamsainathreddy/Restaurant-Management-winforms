using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Models/MenuSection.cs
namespace BarManagementSystem.Models
{
    public class MenuSection
    {
        private int sectionID;
        private int menuID;
        private string name;
        private string types;

        public int SectionID { get { return sectionID; } set { sectionID = value; } }
        public int MenuID { get { return menuID; } set { menuID = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Types { get { return types; } set { types = value; } }
    }
}