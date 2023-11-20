using System;
using System.Collections.Generic;

namespace RanchProject.Models
{
    public partial class Product
    {
        public Product()
        {
            Employees = new HashSet<Employee>();
        }

        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? RanchID { get; set; }

        public virtual Aranch? Ranch { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
