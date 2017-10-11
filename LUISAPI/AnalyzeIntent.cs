using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace LUISAPI
{
    public class AnalyzeIntent
    {
        //api sub key and luis ai application id
        private string appID = "2907f476-41dc-4eff-8846-d79976313cca";
        private string apiKey = "f4de5c691a994913b6a6dbb9a452253b";
        public async Task<dynamic> MakeRequest(string querry, string contextId)
        {
            using (var client = new HttpClient())
            {
                //define the basic address for the api 
                client.BaseAddress = new Uri("https://westus.api.cognitive.microsoft.com");
                //get the response based on the base address and included tags, including the user querry 
                HttpResponseMessage response =
                    await client.GetAsync(client.BaseAddress +
                    $"/luis/v2.0/apps/{appID}?subscription-key={apiKey}&timezoneOffset=0&verbose=true&q={querry}");
                //return the deserialized response to main 
                return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
