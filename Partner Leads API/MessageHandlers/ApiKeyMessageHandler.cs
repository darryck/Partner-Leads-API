using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Partner_Leads_API.MessageHandlers
{
    public class ApiKeyMessageHandler : DelegatingHandler
    {
        private const string ApiKeyToCheck = "565as4df654as65d";
        /*
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {
            bool validKey = false;
            IEnumerable<string> requestHeaders;
            var checkApiKeyExists = httpRequestMessage.Headers.TryGetValues("APIKey", out requestHeaders);
            if (checkApiKeyExists)
            {
                if(requestHeaders.FirstOrDefault().Equals(ApiKeyToCheck))
                {
                    validKey = true;
                }
                if(!validKey)
                {
                    return httpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key");
                }
                var response = await base.SendAsync(httpRequestMessage, cancellationToken);
                return response;
            }
            if(!checkApiKeyExists) return httpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key");
        }
        */
    }
}
