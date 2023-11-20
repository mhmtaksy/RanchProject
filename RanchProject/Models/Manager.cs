using System;
using System.Collections.Generic;

namespace RanchProject.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Aranches = new HashSet<Aranch>();
        }

        public int ManagerID { get; set; }
        public string? ManagerName { get; set; }
        public string? ManagerSurname { get; set; }

        public virtual ICollection<Aranch> Aranches { get; set; }
    }
}
