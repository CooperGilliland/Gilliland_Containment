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
            AnalyzeIntent Analyzer = new AnalyzeIntent();
            Task<string> response = Analyzer.MakeRequest(apiKey, "addeggs");
            Console.WriteLine(response.Result);
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();

        }
        
    }
}
