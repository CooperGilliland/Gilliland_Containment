using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EmotionAPI
{
    /// <summary>
    /// This class was provided by Chris Peterson
    /// </summary>
    public class VideoEmotionRecognition
    {
        private const String apiKey = "fe080a4f9d5d40f58fe266a4a00b1861";
        private const String apiLocation = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognizeinvideo?perFrame";
        // Constraints: MP4, MOV, WMV; <100MB

        private HttpClient requestClient = new HttpClient();

        public VideoEmotionRecognition()
        {
            // Add the API key header to the client
            requestClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
        }

        private async Task<string> PerformRequest(string filePath)
        {
            // Variable to hold the HTTP response
            HttpResponseMessage response;

            // Get the file in terms of bytes and turn the byte array into content
            using (ByteArrayContent content = new ByteArrayContent(File.ReadAllBytes(filePath)))
            {
                // Add a header that says this is an octet stream. The other option is JSON.
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                // Perform the post request to the API using the image content
                response = await requestClient.PostAsync(apiLocation, content);
            }

            // Read the JSON response
            return response.Headers.GetValues("Operation-Location").First();
        }

        private async Task<string> GetResult(string operationLocation)
        {
            HttpResponseMessage response = null;
            dynamic decodedJson;

            do
            {
                Thread.Sleep(15000);

                response = await requestClient.GetAsync(operationLocation).ConfigureAwait(continueOnCapturedContext: false);
                decodedJson = Json.Decode(await response.Content.ReadAsStringAsync());
            } while (decodedJson.status != "Succeeded" && decodedJson.status != "Failed");

            string result = decodedJson.processingResult;
            return result.Replace(@"\", "");
        }

        /// <summary>
        /// Performs the request and waits for the response so all methods calling this don't need to be async
        /// </summary>
        /// <param name="filePath">Path to image file</param>
        /// <returns>JSON response</returns>
        public string PerformRequestAndWaitForResponse(string filePath)
        {
            Task<string> result = PerformRequest(filePath);
            result.Wait();
            Task<string> completed = GetResult(result.Result);
            completed.Wait();
            return completed.Result;
        }
    }
}
