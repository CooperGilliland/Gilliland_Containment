using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeExplorationAPI
{
    public class FaQConnector
    {
        private const string apiKey = "dd2a961a1b4446e38e4315a6f755e201";
        private const string knowledgeBaseId = "fa09e56f-3cd8-4cbf-874c-b4f6b100ded6";
        private Uri uriBase;
        private UriBuilder builder;
        private string results = "";
        /// <summary>
        /// This constructor builds the uri needed to hit the bot's endpoint
        /// </summary>
        public FaQConnector()
        {
            uriBase = new Uri("https://westus.api.cognitive.microsoft.com/qnamaker/v2.0"); //Base uri for MSCS endpoint
            builder = new UriBuilder($"{uriBase}/knowledgebases/{knowledgeBaseId}/generateAnswer"); //Detailed information about which bot to hit
        }
        /// <summary>
        /// Hit the bot endpoint with the user query, and store the result
        /// </summary>
        /// <param name="query"></param>
        public void QueryResult(string query)
        {
            dynamic postBody = $"{{\"question\": \"{query}\"}}"; //package the user query for transmission
            using (WebClient client = new WebClient())
            {
                //set proper encoding 
                client.Encoding = System.Text.Encoding.UTF8;
                //Set default headers and return types 
                client.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
                client.Headers.Add("Content-Type", "application/json");
                //recieve result from hitting endpoint with user query
                results = client.UploadString(builder.Uri, postBody);                
            }            
            return;
        }
        /// <summary>
        /// Format the result from the bot, and output the formatted result
        /// </summary>
        public void formatOutput()
        {
            try
            {
                //Deserialize the bot results
                dynamic res = JsonConvert.DeserializeObject(results);
                //iterate through results
                foreach (var answer in res.answers)
                {
                    //Format the output for each result field 
                    Console.WriteLine("{0}\nThis answer is a {1}% match", answer.answer, answer.score);
                }
            }
            catch
            {
                //Throw if deserialization fails 
                throw new Exception("Unable to deserialize QnA Maker response string.");
            }
        }
    }
}
