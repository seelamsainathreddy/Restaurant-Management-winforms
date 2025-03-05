using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Models/Order.cs
namespace BarManagementSystem.Models
{
    public class Order
    {
        private int orderID;
        private int tableID;
        private double totalAmount;
        private string status;
        private System.DateTime orderTime;
        private List<MenuItem> items;

        public int OrderID { get { return orderID; } set { orderID = value; } }
        public int TableID { get { return tableID; } set { tableID = value; } }
        public double TotalAmount { get { return totalAmount; } set { totalAmount = value; } }
        public string Status { get { return status; } set { status = value; } }
        public System.DateTime OrderTime { get { return orderTime; } set { orderTime = value; } }
        public List<MenuItem> Items { get { return items; } set { items = value; } }

        public Order()
        {
            items = new List<MenuItem>();
        }
    }
}
