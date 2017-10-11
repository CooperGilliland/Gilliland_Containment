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
using Newtonsoft.Json;

namespace Gilliland_DeterminingIntent
{
    class Program
    {
        const string appID = "2907f476-41dc-4eff-8846-d79976313cca";
        const string apiKey = "a5cdbbbe32e246f6b5ddef2fe3ec3d27";
        static void Main(string[] args)
        {
            string contextId = "";
            string question = "add eggs to my shopping list";
            LUISresults lr = new LUISresults();
            Task.Run(async () =>
            {
                lr = await askLUIS(question, contextId);
                Console.WriteLine(JsonConvert.SerializeObject(lr));
            }).Wait();
            while (lr?.dialog?.prompt?.Length > 0)
            {
                Console.Write(lr.dialog.prompt + "  ");
                contextId = lr.dialog.contextId;
                question = question + " " + Console.ReadLine();
                Task.Run(async () =>
                {
                    Console.WriteLine();
                    lr = await askLUIS(question, contextId);
                    Console.WriteLine(JsonConvert.SerializeObject(lr));
                    Console.WriteLine();
                }).Wait();
            }
            //AnalyzeIntent Analyzer = new AnalyzeIntent();
            //Task<string> response = Analyzer.MakeRequest(apiKey, "addeggs");
            //Console.WriteLine(response.Result);
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();

        }
        static async Task<LUISresults> askLUIS(string question, string contextId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://westus.api.cognitive.microsoft.com");

                string id = "2907f476-41dc-4eff-8846-d79976313cca"; 
                string subscriptionKey = "f4de5c691a994913b6a6dbb9a452253b"; 
                HttpResponseMessage response = 
                await client.GetAsync(client.BaseAddress + $"/luis/v2.0/apps/{id}?subscription-key={subscriptionKey}&timezoneOffset=0&verbose=true&q={question}"); 
                if (!response.IsSuccessStatusCode) 
                { 
                    //return $"LUIS did not respond as expected on " + DateTime.Now.ToString(); 
                } 
                return JsonConvert.DeserializeObject<LUISresults>(await response.Content.ReadAsStringAsync());
            }
        }

    }
}
