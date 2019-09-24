
using System.Net.Http; 
using System.Threading.Tasks; 
using System.Net.Http.Headers;

namespace GEO1.1.1.Models
{
    public class CustomHttpClient : HttpClient
    {
        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.DefaultRequestHeaders.ExpectContinue = false;

            request.Headers.Authorization = Credentials.GetAuthenticationHeader();
            return base.SendAsync(request, cancellationToken);
        }
    }
}