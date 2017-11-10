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
        private const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search?q=";
        private WebRequest webSearchRequest;
        private UriBuilder builder;
        private string results = "";
        public UrlSearch()
        {
            webSearchRequest.Headers["Ocp-Apim-Subscription-Key"] = apiKey;
        }
        public struct SearchResult
        {
            public String jsonResult;
            public Dictionary<String, String> relevantHeaders;
        }
        public SearchResult BingWebSearch(string userQuery)
        {
            var UriQuery = uriBase + Uri.EscapeDataString(userQuery);
            webSearchRequest = WebRequest.Create(UriQuery);            
            HttpWebResponse searchResponse = (HttpWebResponse)webSearchRequest.GetResponseAsync().Result;
            results = new StreamReader(searchResponse.GetResponseStream()).ReadToEnd();
            SearchResult collectResults = new SearchResult()
            {
                jsonResult = results,
                relevantHeaders = new Dictionary<String, String>()
                
            };
            return collectResults;
        }
    }
}
