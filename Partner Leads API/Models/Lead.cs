using System;
using System.Collections.Generic;

#nullable disable

namespace Partner_Leads_API
{
    public partial class Lead
    {
        public int LeadId { get; set; }
        public int? SalesRepId { get; set; }
        public string CustomerFullName { get; set; }
        public string Address { get; set; }
        public string LeadStatus { get; set; }
        public DateTime? InstallDate { get; set; }
        public int? PartnerCompanyId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
