using System;
using System.Collections.Generic;

#nullable disable

namespace Partner_Leads_API.Models
{
    public partial class Manager
    {
        public Manager()
        {
            SalesReps = new HashSet<SalesRep>();
        }

        public int ManagerId { get; set; }
        public string ManagerFullName { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<SalesRep> SalesReps { get; set; }
    }
}
