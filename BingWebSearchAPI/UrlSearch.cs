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
        //private class variables 
        private const string apiKey = "8dc0c73ada3945878baa7ae1ec7377fe"; //Insert MSCS key here 
        private const string uriBase = "https://api.cognitive.microsoft.com/bing/v5.0/search?q=";
        private int totalResultsRequested = 5;
        private WebRequest webSearchRequest;
        private UriBuilder builder;
        private string results = "";
        /// <summary>
        /// Package a user query as a Web request
        /// Return the response from that request
        /// </summary>
        /// <param name="userQuery"></param>
        /// <returns></returns>
        public SearchResult BingWebSearch(string userQuery)
        {
            //Build the Url needed to hit the api endpoint
            var UriQuery = uriBase + Uri.EscapeDataString(userQuery) + $"&count={totalResultsRequested}";
            webSearchRequest = WebRequest.Create(UriQuery); //Use the url to create a web request 
            webSearchRequest.Headers["Ocp-Apim-Subscription-Key"] = apiKey; //Set the required header to gaiun access to the api
            HttpWebResponse searchResponse = (HttpWebResponse)webSearchRequest.GetResponseAsync().Result; //Get the response from the endpoint 
            //Read through the endpoint response, placing everything into a string
            results = new StreamReader(searchResponse.GetResponseStream() ?? throw new InvalidOperationException()).ReadToEnd();
            SearchResult collectResults = new SearchResult(); 
            //Add the string of results to the search result helper class 
            collectResults.SetjsonResults(results);
            return collectResults;
        }
    }
}
