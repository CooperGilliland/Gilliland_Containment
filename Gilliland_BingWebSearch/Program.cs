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
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("This Application takes user querys to the Bing search engine\n" +
                                  "And gives back the top five web addresses, and their information.\n");
                Console.Write("Please enter your search query now. \n-> ");
                string searchTerm = Console.ReadLine();
                UrlSearch WebQuery = new UrlSearch();
                SearchResult result = WebQuery.BingWebSearch(searchTerm);
                Console.WriteLine("\nRelevant HTTP Headers:\n");
                result.FormatOutput();
                Console.Write("\nPress Enter to exit ");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Write("\nPress Enter to exit ");
                Console.ReadLine();
            }
        }
    }
}
