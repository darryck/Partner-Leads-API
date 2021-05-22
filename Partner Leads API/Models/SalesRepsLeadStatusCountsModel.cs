using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Partner_Leads_API.Models
{
    public class SalesRepsLeadStatusCountsModel
    {
        public int SalesRepId { get; set; }
        public string SalesRepName { get; set; }
        public int CountOfCancelled { get; set; }
        public int CountOfInstalled { get; set; }
        public int CountOfTroubled { get; set; }
    }
}
