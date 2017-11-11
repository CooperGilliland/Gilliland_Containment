using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BingWebSearchAPI
{
    public class SearchResult
    {
        public String jsonResult; //TODO: Change to private
        public Dictionary<String, String> relevantHeaders;

        public void FormatOutput()
        {
            int i = 0;
            dynamic dynamDeserializeObjectJson = JsonConvert.DeserializeObject(jsonResult);
            foreach (var region in dynamDeserializeObjectJson.webPages.value)
            {                
                i++;
                Console.WriteLine("\nResult {0}:\n\tName: {1}\n\tURL: {2}\n\tDescription: {3}",i,region.name,region.displayUrl,region.snippet);               
            }
        }
    }
}
