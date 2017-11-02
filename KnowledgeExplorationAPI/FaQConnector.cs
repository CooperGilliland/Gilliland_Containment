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
        public FaQConnector()
        {
            uriBase = new Uri("https://westus.api.cognitive.microsoft.com/qnamaker/v2.0");
            builder = new UriBuilder($"{uriBase}/knowledgebases/{knowledgeBaseId}/generateAnswer");
        }
        public FaQHelper QueryResult(string query)
        {
            dynamic postBody = $"{{\"question\": \"{query}\"}}";
            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                client.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
                client.Headers.Add("Content-Type", "application/json");
                results = client.UploadString(builder.Uri, postBody);
            }
            FaQHelper response;
            try
            {
                response = JsonConvert.DeserializeObject<FaQHelper>(results);
            }
            catch
            {
                throw new Exception("Unable to deserialize QnA Maker response string.");
            }
            return response;
        }
    }
}
