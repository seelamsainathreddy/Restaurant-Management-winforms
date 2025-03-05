using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarManagementSystem.Models
{
    public class Table
    {
        private int tableID;
        private int barID;
        private int capacity;
        private bool isOccupied;

        public int TableID { get { return tableID; } set { tableID = value; } }
        public int BarID { get { return barID; } set { barID = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public bool IsOccupied { get { return isOccupied; } set { isOccupied = value; } }
    }
}
