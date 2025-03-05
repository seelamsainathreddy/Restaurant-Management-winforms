using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarManagementSystem.Models
{
    public class Bar
    {
        private int barID;
        private string name;
        private string address;
        private string phoneNumber;
        private string password;

        public int BarID { get { return barID; } set { barID = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Password { get { return password; } set { password = value; } }
    }
}