using System;
using System.Collections.Generic;

namespace RanchProject.Models
{
    public partial class Aranch
    {
        public Aranch()
        {
            Products = new HashSet<Product>();
        }

        public int RanchID { get; set; }
        public string? RanchName { get; set; }
        public string? RanchAdress { get; set; }
        public int? RanchNoe { get; set; }
        public decimal? RanchGiro { get; set; }
        public int? ManagerID { get; set; }

        public virtual Manager? Manager { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
