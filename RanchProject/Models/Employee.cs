using System;
using System.Collections.Generic;

namespace RanchProject.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Customers = new HashSet<Customer>();
        }

        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeSurname { get; set; }
        public string? EmployeeWage { get; set; }
        public int? ProductID { get; set; }

        public virtual Product? Product { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
