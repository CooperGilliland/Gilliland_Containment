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
        private String jsonResult;
        /// <summary>
        /// Mutator for class variable 
        /// </summary>
        /// <param name="incomingJsonResult"></param>
        public void SetjsonResults(String incomingJsonResult)
        {
            jsonResult = incomingJsonResult;
        }
        /// <summary>
        /// Accessor for private varaible 
        /// </summary>
        /// <returns></returns>
        public String GetjsonResults()
        {
            return jsonResult;
        }
        /// <summary>
        /// Extract and ouput the desired information from a JSON
        /// </summary>
        public void FormatOutput()
        {
            int i = 0;
            //Deserialize JSON object
            dynamic dynamDeserializeObjectJson = JsonConvert.DeserializeObject(jsonResult);
            //Iterate through JSON
            foreach (var region in dynamDeserializeObjectJson.webPages.value)
            {                
                i++;
                //Output the desired information from the JSON
                Console.WriteLine("\nResult {0}:\n\tName: {1}\n\tURL: {2}\n\tDescription: {3}",i,region.name,region.displayUrl,region.snippet);               
            }
        }
    }
}
