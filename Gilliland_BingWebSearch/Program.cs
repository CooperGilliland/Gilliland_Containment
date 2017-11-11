using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingWebSearchAPI;
namespace Gilliland_BingWebSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                string searchTerm = "Higgs Boson";
                UrlSearch WebQuery = new UrlSearch();
                SearchResult result = WebQuery.BingWebSearch(searchTerm);
                Console.WriteLine("\nRelevant HTTP Headers:\n");
                foreach (var header in result.relevantHeaders)
                {
                    Console.WriteLine(header.Key + ": " + header.Value);
                }
                result.FormatOutput();
                Console.Write("\nPress Enter to exit ");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
    }
}
