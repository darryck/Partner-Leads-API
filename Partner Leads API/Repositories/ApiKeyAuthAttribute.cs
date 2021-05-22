using System.Linq;

namespace Partner_Leads_API.Repositories
{
    public class ApiKeyAuthAttribute : IApiKeyAuthAttribute
    {

        public bool CheckUser(string apikey)
        {
            using var context = new PartnerLeadsContext();
            if (context.PartnerCompanies.Where(l => l.ApiKey == apikey) == null) return false;
            return true;
        }
    }
}
