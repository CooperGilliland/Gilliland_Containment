using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingSpeechAPI;
using Newtonsoft.Json;
namespace Gilliland_SpeachToText
{
    class Program
    {
        //assign the base endpoint for the application 
        private const string uri =
                "https://speech.platform.bing.com/speech/recognition/conversation/cognitiveservices/v1?language=en-US&format=detailed";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This Application takes the filepath to an audio file\n" +
                                  "of up to 15 seconds that contains human speech \n" +
                                  "and transcribes that audio into text.\n");
                //create new speech to text converter and hand it the api endpoint 
                STT converter = new STT(uri);             
                Console.Write("Enter your filepath now -> ");
                string filePath = Console.ReadLine();
                //send audio file to be processed  
                converter.SendData(filePath);
                //get response back from endpoint 
                string result = converter.GetResponse();
                //process the response 
                dynamic deserialJson = JsonConvert.DeserializeObject(result);
                //output only the desired data from the response 
                foreach (var ttsRes in deserialJson.NBest)
                {
                    Console.WriteLine("The transciption of your audio file is as follows:\n{0}", ttsRes.Display);
                }
                Console.WriteLine("\nPress Enter to Quit");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                Console.ReadLine();
            }
        }
    }
}
