using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LUISAPI
{
    public class AnalyzeIntent
    {
        public async Task<string> MakeRequest(string apiKey, string subject)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            queryString["timezoneOffset"] = "0";
            queryString["verbose"] = "true";
            var uri =
                "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/2907f476-41dc-4eff-8846-d79976313cca?subscription-key=089c9223a47d40db93b4402afdaa8593&timezoneOffset=0&verbose=true&q=" +
              "&q=" + subject;
            
            
            HttpResponseMessage response;
            response = await client.GetAsync(uri);

            string finalContent = await response.Content.ReadAsStringAsync();
            return finalContent;
            /*
            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(subject);
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                string finalContent = await response.Content.ReadAsStringAsync();
                return finalContent;
            }
            */
        }
    }
}
