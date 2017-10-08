using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LUISAPI;
using Microsoft.Cognitive.LUIS;

namespace Gilliland_DeterminingIntent
{
    class Program
    {
        const string appID = "2907f476-41dc-4eff-8846-d79976313cca";
        const string apiKey = "f4de5c691a994913b6a6dbb9a452253b";
        static void Main(string[] args)
        {
            MakeRequest();
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
            /*
            Luis _luis = new Luis(new LuisClient(appID, apiKey));
            string request = Console.ReadLine();
            _luis.RequestAsync(request);
            while (_luis.isRunning) { }
            Console.ReadLine();
            */

        }
        static async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            queryString["timezoneOffset"] = "1";
            queryString["verbose"] = "true";
            queryString["spellCheck"] = "false";
            queryString["staging"] = "false";
            var uri = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/2907f476-41dc-4eff-8846-d79976313cca?" + queryString;
            HttpResponseMessage response;
            string request = "add eggs to list";
            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("add eggs to list");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                string finalContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(finalContent);
            }

        }
    }
}
