using System;
using System.Collections.Generic;

namespace RanchProject.Models
{
    public partial class Customer
    {
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurname { get; set; }
        public bool? CustomerGender { get; set; }
        public int? EmployeeID { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
