using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Partner_Leads_API.Repositories
{
    public interface IApiKeyAuthAttribute
    {
        bool CheckUser(string apikey);
    }
}
