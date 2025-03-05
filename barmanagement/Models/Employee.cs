using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Models/Employee.cs
namespace BarManagementSystem.Models
{
    public class Employee
    {
        private int employeeID;
        private string name;
        private string role;
        private double salary;

        public int EmployeeID { get { return employeeID; } set { employeeID = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Role { get { return role; } set { role = value; } }
        public double Salary { get { return salary; } set { salary = value; } }
    }
}
