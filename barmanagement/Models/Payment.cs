using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Models/Payment.cs
namespace BarManagementSystem.Models
{
    public class Payment
    {
        private int paymentID;
        private int orderID;
        private double amount;
        private string paymentMethod;
        private System.DateTime paymentDate;

        public int PaymentID { get { return paymentID; } set { paymentID = value; } }
        public int OrderID { get { return orderID; } set { orderID = value; } }
        public double Amount { get { return amount; } set { amount = value; } }
        public string PaymentMethod { get { return paymentMethod; } set { paymentMethod = value; } }
        public System.DateTime PaymentDate { get { return paymentDate; } set { paymentDate = value; } }
    }
}