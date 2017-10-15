using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace BingSpeechAPI
{
    public class STT
    {
        private HttpWebRequest apiRequest = null;
        private string responseString = "";
        private string apiKey = "5e00e08e2ad54600a7ed2c5d1d5aed95";
        /// <summary>
        /// Constuctor is used to build Http request for api call 
        /// </summary>
        /// <param name="requestUri"></param>
        public STT(string requestUri)
        {
            //build the request with the data needed to query the api 
            apiRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            apiRequest.SendChunked = true;
            apiRequest.Accept = @"application/json;text/xml";
            apiRequest.Method = "POST";
            apiRequest.ProtocolVersion = HttpVersion.Version11;
            apiRequest.ContentType = @"audio/wav; codec=audio/pcm; samplerate=16000";
            apiRequest.Headers["Ocp-Apim-Subscription-Key"] = apiKey;
        }
        /// <summary>
        /// process and transmit audio file to endpoint 
        /// </summary>
        /// <param name="fileLocation"></param>
        /// <returns></returns>
        public void SendData(string fileLocation)
        {
            //open and read the audio file 
            using (FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read))
            {
                //declare local variables 
                byte[] buffer = null;
                int bytesRead = 0;
                //get stream item to write request data 
                using (Stream requestStream = apiRequest.GetRequestStream())
                {
                    //create a buffer to be used in chunking the audio file 
                    buffer = new Byte[checked((uint)Math.Min(1024, (int)fs.Length))];
                    //keep writing to the endpoint unit the end of file is reached 
                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        requestStream.Write(buffer, 0, bytesRead);
                    }

                    //empty the stream 
                    requestStream.Flush();
                }
            }
        }
        /// <summary>
        /// Get the response back from the endpoint 
        /// </summary>
        /// <returns></returns>
        public string GetResponse()
        {
            //get a response from the endpoint api 
            using (WebResponse response = apiRequest.GetResponse())
            {
                //get the response as a stream 
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    //process that stream into a class variable 
                    responseString = sr.ReadToEnd();
                }
                //return the results for later use 
                return responseString;
            }
        }
    }
}
