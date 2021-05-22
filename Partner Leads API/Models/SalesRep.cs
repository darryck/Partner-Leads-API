using System;
using System.Collections.Generic;

#nullable disable

namespace Partner_Leads_API
{
    public partial class SalesRep
    {
        public int SalesRepId { get; set; }
        public int ManagerId { get; set; }
        public string RepFullName { get; set; }

        public virtual Manager Manager { get; set; }
    }
}
