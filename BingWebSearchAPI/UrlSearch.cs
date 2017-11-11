using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BingWebSearchAPI
{
    public class UrlSearch
    {
        private const string apiKey = "8dc0c73ada3945878baa7ae1ec7377fe"; //Insert MSCS key here 
        private const string uriBase = "https://api.cognitive.microsoft.com/bing/v5.0/search?q=";
        private int totalResultsRequested = 5;
        private WebRequest webSearchRequest;
        private UriBuilder builder;
        private string results = "";
        public SearchResult BingWebSearch(string userQuery)
        {
            var UriQuery = uriBase + Uri.EscapeDataString(userQuery) + $"&count={totalResultsRequested}";
            webSearchRequest = WebRequest.Create(UriQuery);
            webSearchRequest.Headers["Ocp-Apim-Subscription-Key"] = apiKey;
            HttpWebResponse searchResponse = (HttpWebResponse)webSearchRequest.GetResponseAsync().Result;
            results = new StreamReader(searchResponse.GetResponseStream() ?? throw new InvalidOperationException()).ReadToEnd();
            SearchResult collectResults = new SearchResult()
            {
                jsonResult = results,
                relevantHeaders = new Dictionary<String, String>()              
            };
            foreach (String header in searchResponse.Headers)
            {
                if (header.StartsWith("BingAPIs-") || header.StartsWith("X-MSEdge-"))
                    collectResults.relevantHeaders[header] = searchResponse.Headers[header];
            }
            return collectResults;
        }
    }
}
