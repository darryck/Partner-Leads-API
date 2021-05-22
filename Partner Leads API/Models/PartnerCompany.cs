using System;
using System.Collections.Generic;

#nullable disable

namespace Partner_Leads_API.Models
{
    public partial class PartnerCompany
    {
        public int PartnerCompanyId { get; set; }
        public string PartnerName { get; set; }
        public string ApiKey { get; set; }
    }
}
